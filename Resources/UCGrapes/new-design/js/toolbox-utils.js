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