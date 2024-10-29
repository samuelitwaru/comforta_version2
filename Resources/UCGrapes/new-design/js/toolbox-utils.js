function nestPages(pages) {
    const pageMap = {};
    const nestedPages = new Set();
  
    // Create a map for easy reference by PageId
    pages.forEach(page => {
      pageMap[page.PageId] = { id: page.PageId, name: page.PageName, children: [] };
    });
    // Function to recursively find and add nested pages
    function addNestedPages(tile, parentPage) {
      if (tile.ToPageId && pageMap[tile.ToPageId]) {
        const nestedPage = pageMap[tile.ToPageId];
        parentPage.children.push(nestedPage);
        nestedPages.add(nestedPage.PageId);
      }
    }
  
    // Iterate over each page and find nested pages from the tiles
    pages.forEach(page => {
      if (page.Row) {
        page.Row.forEach(row => {
          if (row.Col){
            row.Col.forEach(col => {
              if (col.Tile) {
                addNestedPages(col.Tile, pageMap[page.PageId]);
              }
            });
          }
        });
      }
    });
  
    // Filter out pages that are nested in other pages
    const rootPages = pages.filter(page => !nestedPages.has(page.PageId));
  
    return rootPages.map(page => pageMap[page.PageId]);
}

function mapTemplateToPageData(templateData) {
  // Helper function to generate UUID
  function generateUUID() {
    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
      /[xy]/g,
      function (c) {
        const r = (Math.random() * 16) | 0;
        const v = c === "x" ? r : (r & 0x3) | 0x8;
        return v.toString(16);
      }
    );
  }

  // Create the base page structure
  const pageData = {
    PageId: generateUUID(),
    PageName: "Home",
    Row: [],
  };

  // Find container-column in template data
  const containerColumn = (() => {
    const pages = templateData.pages || [];
    for (const page of pages) {
      for (const frame of page.frames || []) {
        const container =
          frame.component?.components?.[0]?.components?.[0];
        if (container?.classes?.includes("container-column")) {
          return container;
        }
      }
    }
    return null;
  })();

  if (!containerColumn) return pageData;

  // Find and map container rows
  const containerRows =
    containerColumn.components?.filter((comp) =>
      comp.classes?.includes("container-row")
    ) || [];

  // Map rows to final structure
  pageData.Row = containerRows.map((rowComponent) => {
    const row = {
      RowId: generateUUID(),
      RowName: generateUUID(),
      Col: [],
    };

    // Find and map templates to columns
    const templates =
      rowComponent.components?.filter(
        (comp) =>
          comp.type === "template-wrapper" &&
          !comp.classes?.includes("container-row")
      ) || [];

    row.Col = templates.map((templateComponent) => {
      // Map column
      const col = {
        ColId: generateUUID(),
        ColName: generateUUID(),
        Tile: null,
      };

      // Map tile
      const attributes = templateComponent.attributes || {};

      // Find tile title
      const templateBlock = templateComponent.components?.find((comp) =>
        comp.classes?.includes("template-block")
      );
      const titleSection = templateBlock?.components?.find((comp) =>
        comp.classes?.includes("tile-title-section")
      );
      const titleSpan = titleSection?.components?.find((comp) =>
        comp.classes?.includes("tile-title")
      );
      const titleText = titleSpan?.components?.[0]?.content || "";

      // Create tile object
      col.Tile = {
        TileId: generateUUID(),
        TileName: titleText,
        TileIcon: attributes["tile-icon"] || "",
        TileBGColor: attributes["tile-bgcolor"] || "",
        TileBGImageUrl: attributes["tile-bg-image-url"] || "",
        TileTextColor: "", // Not present in source data
        TileTextAlignment: attributes["tile-text-align"] || "center",
        TileIconAlignment: attributes["tile-icon-align"] || "center",
        ProductServiceId: "00000000-0000-0000-0000-000000000000",
        ProductServiceName: "",
        ProductServiceDescription: "",
        ProductServiceImage: "",
        ToPageId: generateUUID(),
        ToPageName: titleText,
      };

      return col;
    });

    return row;
  });

  return pageData;
}