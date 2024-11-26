let globalVar = null;
class ToolBoxManager {
  dataManager = null;
  constructor(
    editorManager,
    dataManager,
    themes,
    icons,
    templates,
    mapping,
    media,
    currentLanguage
  ) {
    this.editorManager = editorManager;
    this.dataManager = dataManager;
    this.themes = themes;
    this.icons = icons;
    this.currentTheme = null;
    this.templates = templates;
    this.mappingsItems = mapping;
    this.selectedFile = null;
    this.media = media;
    this.currentLanguage = currentLanguage;
    // this.init();
  }

  init() {
    let self = this;
    this.dataManager.getPages().then((pages) => {
      localStorage.clear();
      pages.forEach((page) => {
        if (page.PageName === "Home") {
          this.editorManager.pageId = page.PageId;
          this.editorManager.setCurrentPage(page);
          this.editorManager.editor.trigger("load");
        }
      });
    });

    this.dataManager.getLocationTheme().then(theme=>{
      this.setTheme(theme.Trn_ThemeName)
    })

    this.loadTheme();
    this.listThemesInSelectField();
    this.colorPalette();
    this.ctaColorPalette();
    // this.pageContentCtas();
    // this.loadThemeIcons();
    this.loadPageTemplates();

    this.actionList = new ActionListComponent(
      this.editorManager,
      this.dataManager,
      this.currentLanguage,
      this
    );

    this.mediaComponent = new MediaComponent(
      this.dataManager,
      this.editorManager,
      this
    );
    const tabButtons = document.querySelectorAll(".toolbox-tab-button");
    const tabContents = document.querySelectorAll(".toolbox-tab-content");
    tabButtons.forEach((button) => {
      button.addEventListener("click", (e) => {
        e.preventDefault();
        tabButtons.forEach((btn) => btn.classList.remove("active"));
        tabContents.forEach((content) =>
          content.classList.remove("active-tab")
        );

        button.classList.add("active");
        document
          .querySelector(`#${button.dataset.tab}-content`)
          .classList.add("active-tab");
      });
    });

    // mapping
    const mappingButton = document.getElementById("open-mapping");
    const publishButton = document.getElementById("publish");
    const mappingSection = document.getElementById("mapping-section");
    const toolsSection = document.getElementById("tools-section");

    this.mappingComponent = new MappingComponent(
      this.dataManager,
      this.editorManager,
      this
    );

    mappingButton.addEventListener("click", (e) => {
      e.preventDefault();

      toolsSection.style.display =
        toolsSection.style.display === "none" ? "block" : "none";

      mappingSection.style.display =
        mappingSection.style.display === "block" ? "none" : "block";

      this.mappingComponent.init();
    });

    publishButton.onclick = (e) => {
      e.preventDefault();
      let projectData = this.editorManager.editor.getProjectData();
      let htmlData = this.editorManager.editor.getHtml();
      let jsonData;

      let pageId = this.editorManager.getCurrentPageId();

      const pageIsContent = this.dataManager.pages.find((page) => page.PageId === pageId);
      if (pageIsContent.PageIsContentPage) {
        jsonData = mapContentToPageData(projectData)
        console.log("ProjectData is: ", jsonData)
      } else {
        jsonData = mapTemplateToPageData(projectData);
        console.log("ProjectData is: ", jsonData)
      }
      
      if (pageId) {
        let data = {
          PageId: pageId,
          PageName: pageIsContent.PageName,
          PageJsonContent: JSON.stringify(jsonData),
          PageGJSHtml: htmlData,
          PageGJSJson: JSON.stringify(projectData),
          SDT_Page: jsonData,
          PageIsPublished: true,
        };
        this.dataManager.updatePage(data).then((res) => {
          this.displayAlertMessage("Page Save Successfully", "success");
        });
      }
    };

    // tile title alignment
    const leftAlign = document.getElementById("text-align-left");
    const centerAlign = document.getElementById("text-align-center");
    const rightAlign = document.getElementById("text-align-right");

    leftAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-title-section")[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "start",
          });
          this.setAttributeToSelected("tile-text-align", "left");
        }
      }
    });

    centerAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-title-section")[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "center",
          });
          this.setAttributeToSelected("tile-text-align", "center");
        }
      }
    });

    rightAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-title-section")[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "end",
          });
          this.setAttributeToSelected("tile-text-align", "right");
        }
      }
    });

    // tile icon alignment
    const iconLeftAlign = document.getElementById("icon-align-left");
    const iconCenterAlign = document.getElementById("icon-align-center");
    const iconRightAlign = document.getElementById("icon-align-right");

    iconLeftAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-icon-section")[0];
        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "start",
          });
          this.setAttributeToSelected("tile-icon-align", "left");
        }
      }
    });

    iconCenterAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-icon-section")[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "center",
          });
          this.setAttributeToSelected("tile-icon-align", "center");
        }
      }
    });

    iconRightAlign.addEventListener("click", () => {
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".tile-icon-section")[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "end",
          });
          this.setAttributeToSelected("tile-icon-align", "right");
        }
      }
    });

    // apply opacity to a bg image of a selected tile
    const imageOpacity = document.getElementById("bg-opacity");

    imageOpacity.addEventListener("input", (event) => {
      const value = event.target.value;

      // add opacity to selected tile image
      if (this.editorManager.selectedTemplateWrapper) {
        const templateBlock = this.editorManager.editor
          .getSelected()
          .find(".template-block")[0];

        if (templateBlock) {
          templateBlock.addStyle({
            opacity: value / 100,
          });
        }
      }
    });

    // undo and redo
    const um = this.editorManager.editor.UndoManager;
    //undo
    const undoButton = document.getElementById("undo");
    undoButton.addEventListener("click", (e) => {
      e.preventDefault();
      if (um.hasUndo()) {
        um.undo();
      }
    });

    // redo
    const redoButton = document.getElementById("redo");
    redoButton.addEventListener("click", (e) => {
      e.preventDefault();
      if (um.hasRedo()) {
        um.redo();
      }
    });
  }

  listThemesInSelectField() {
    const themeSelect = document.getElementById("theme-select");

    this.themes.forEach((theme) => {
      console.log("theme", theme);
      const option = document.createElement("option");
      option.value = theme.name;
      option.textContent = theme.name;
      option.id = theme.id;

      themeSelect.appendChild(option);
    });

    themeSelect.addEventListener("change", (e) => {
      const themeName = e.target.value;
      // update location theme
      this.dataManager.selectedTheme = this.themes.find(
        (theme) => theme.name === themeName
      );

      this.dataManager.updateLocationTheme();

      if (this.setTheme(themeName)) {
        this.themeColorPalette(this.currentTheme.colors);

        localStorage.setItem("selectedTheme", themeName);

        const message = this.currentLanguage.getTranslation(
          "theme_applied_success_message"
        );
        const status = "success";
        this.displayAlertMessage(message, status);
      } else {
        const message = this.currentLanguage.getTranslation(
          "error_applying_theme_message"
        );
        const status = "error";
        this.displayAlertMessage(message, status);
      }
    });
  }

  loadTheme() {
    const savedTheme = localStorage.getItem("selectedTheme");
    if (savedTheme) {
      this.setTheme(savedTheme);
    }
  }

  setTheme(themeName) {
    const theme = this.themes.find((theme) => theme.name === themeName);
    document.getElementById("theme-select").value = themeName
    console.log(theme);
    if (!theme) {
      return false;
    }

    this.currentTheme = theme;
    this.applyTheme();

    // TODO: Apply theme attribute to json out output (research on editor methods to do this)
    let wrapper = this.editorManager.editor.getWrapper();
    wrapper.addAttributes({ theme: theme.name });
    this.icons = theme.icons.map((icon) => {
      return {
        name: icon.IconName,
        svg: icon.IconSVG,
        category: icon.IconCategory,
      };
    });
    this.loadThemeIcons(theme.icons);

    this.themeColorPalette(this.currentTheme.colors);
    localStorage.setItem("selectedTheme", themeName);

    return true;
  }

  applyTheme() {
    const root = document.documentElement;
    const iframe = document.querySelector("#gjs iframe");

    // Set CSS variables from the selected theme
    root.style.setProperty(
      "--primary-color",
      this.currentTheme.colors.primaryColor
    );
    root.style.setProperty(
      "--secondary-color",
      this.currentTheme.colors.secondaryColor
    );
    root.style.setProperty(
      "--background-color",
      this.currentTheme.colors.backgroundColor
    );
    root.style.setProperty("--text-color", this.currentTheme.colors.textColor);
    root.style.setProperty(
      "--button-bg-color",
      this.currentTheme.colors.buttonBgColor
    );
    root.style.setProperty(
      "--button-text-color",
      this.currentTheme.colors.buttonTextColor
    );
    root.style.setProperty(
      "--card-bg-color",
      this.currentTheme.colors.cardBgColor
    );
    root.style.setProperty(
      "--card-text-color",
      this.currentTheme.colors.cardTextColor
    );
    root.style.setProperty(
      "--accent-color",
      this.currentTheme.colors.accentColor
    );
    root.style.setProperty("--font-family", this.currentTheme.fontFamily);

    // Apply this.currentTheme to iframe (canvas editor)
    const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
    iframeDoc.body.style.setProperty(
      "--primary-color",
      this.currentTheme.colors.primaryColor
    );
    iframeDoc.body.style.setProperty(
      "--secondary-color",
      this.currentTheme.colors.secondaryColor
    );
    iframeDoc.body.style.setProperty(
      "--background-color",
      this.currentTheme.colors.backgroundColor
    );
    iframeDoc.body.style.setProperty(
      "--text-color",
      this.currentTheme.colors.textColor
    );
    iframeDoc.body.style.setProperty(
      "--button-bg-color",
      this.currentTheme.colors.buttonBgColor
    );
    iframeDoc.body.style.setProperty(
      "--button-text-color",
      this.currentTheme.colors.buttonTextColor
    );
    iframeDoc.body.style.setProperty(
      "--card-bg-color",
      this.currentTheme.colors.cardBgColor
    );
    iframeDoc.body.style.setProperty(
      "--card-text-color",
      this.currentTheme.colors.cardTextColor
    );
    iframeDoc.body.style.setProperty(
      "--accent-color",
      this.currentTheme.colors.accentColor
    );
    iframeDoc.body.style.setProperty(
      "--font-family",
      this.currentTheme.fontFamily
    );
  }

  themeColorPalette(colors) {
    const colorPaletteContainer = document.getElementById(
      "theme-color-palette"
    );
    colorPaletteContainer.innerHTML = "";

    const colorEntries = Object.entries(colors);

    colorEntries.forEach(([colorName, colorValue], index) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";
      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `color-${colorName}`;
      radioInput.name = "theme-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-bgcolor", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);

      colorPaletteContainer.appendChild(alignItem);

      colorBox.onclick = () => {
        this.editorManager.selectedComponent.addStyle({
          "background-color": colorValue,
        });
        this.setAttributeToSelected("tile-bgcolor", colorValue);
      };
    });
  }

  colorPalette() {
    const textColorPaletteContainer =
      document.getElementById("text-color-palette");
    const iconColorPaletteContainer =
      document.getElementById("icon-color-palette");

    // Fixed color values
    const colorValues = {
      color1: "#ffffff", // Example white
      color2: "#333333", // Example dark gray
      // Add more colors as needed
    };

    // Create options for text color palette
    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";

      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `text-color-${colorName}`;
      radioInput.name = "text-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `text-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-text-color", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);
      textColorPaletteContainer.appendChild(alignItem);

      radioInput.onclick = () => {
        this.editorManager.selectedComponent.addStyle({
          color: colorValue,
        });
        this.setAttributeToSelected("tile-text-color", colorValue);
      };
    });

    // Create options for icon color palette
    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";

      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `icon-color-${colorName}`;
      radioInput.name = "icon-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `icon-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-icon-color", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);
      iconColorPaletteContainer.appendChild(alignItem);

      radioInput.onclick = () => {
        const svgIcon = this.editorManager.editor
          .getSelected()
          .find(".tile-icon path")[0];
        if (svgIcon) {
          svgIcon.removeAttributes("fill");
          svgIcon.addAttributes({ fill: colorValue });
          this.setAttributeToSelected("tile-icon-color", colorValue);
        } else {
          const message = this.currentLanguage.getTranslation(
            "no_icon_selected_error_message"
          );
          this.displayAlertMessage(message, "error");
        }
      };
    });
  }

  ctaColorPalette() {
    const ctaColorPaletteContainer =
      document.getElementById("cta-color-palette");
    // Fixed color values
    const colorValues = {
      color1: "#4C9155",
      color2: "#5068A8",
      color3: "#EEA622",
      color4: "#FF6C37",
    };

    // Create options for text color palette
    console.log(colorValues);
    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const colorItem = document.createElement("div");
      colorItem.className = "color-item";
      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `cta-color-${colorName}`;
      radioInput.name = "cta-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `cta-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-cta-color", colorValue);

      colorItem.appendChild(radioInput);
      colorItem.appendChild(colorBox);
      ctaColorPaletteContainer.appendChild(colorItem);

      radioInput.onclick = () => {
        if (this.editorManager.selectedComponent) {
          const selectedComponent = this.editorManager.selectedComponent;

          // Search for components with either class
          const componentsWithClass = [
            ...selectedComponent.find(".cta-main-button"),
            ...selectedComponent.find(".cta-button"),
          ];

          // Get the first matching component
          const button =
            componentsWithClass.length > 0 ? componentsWithClass[0] : null;

          if (button) {
            button.addStyle({
              "background-color": colorValue,
            });
          }
          this.setAttributeToSelected("cta-background-color", colorValue);
        }
      };
    });
  }

  pageContentCtas(callToActions) {
    const contentPageCtas = document.getElementById("call-to-actions");

    const renderCtas = () => {
      contentPageCtas.innerHTML = "";

      callToActions.forEach((cta) => {
        const ctaItem = document.createElement("div");
        ctaItem.classList.add("call-to-action-item");
        ctaItem.title = cta.CallToActionName;

        let iconHtml = "";
        switch (cta.CallToActionType) {
          case "Phone":
            iconHtml = '<i class="fa fa-phone-volume"></i>';
            const phoneComponent = `
            <div class="cta-container-child cta-child" 
              data-gjs-draggable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              cta-button-label-id="${cta.CallToActionId}"
              cta-button-label="${cta.CallToActionName}"
              cta-button-type="${cta.CallToActionType}"
              cta-button-action="${cta.CallToActionPhone}"
              cta-background-color="#5068a8"
            >
              <div class="cta-button" ${defaultConstraints}>
                <i class="fas fa-phone-alt" ${defaultConstraints}></i>
                <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
              </div>
              <div class="cta-label" ${defaultConstraints}>${cta.CallToActionName}</div>
              </div>
            `;
            ctaItem.onclick = (e) => {
              e.preventDefault();
              const phoneCtaButton = this.editorManager.editor
                .getWrapper()
                .find(".cta-button-container")[0];

              if (phoneCtaButton) {
                const existingComponent = phoneCtaButton.find(
                  ".cta-container-child .fas.fa-phone-alt"
                )[0];

                if (existingComponent) {
                  const message =
                    this.currentLanguage.getTranslation("cta_button_exists");
                  this.displayAlertMessage(message, "error");
                  return; // Exit if the component already exists
                }
                phoneCtaButton.append(phoneComponent);
              }
            };
            break;

          case "Email":
            iconHtml = '<i class="fa fa-envelope"></i>';
            const emailComponent = `
          <div class="cta-container-child cta-child"
              data-gjs-draggable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              cta-button-id="${cta.CallToActionId}"
              cta-button-label="${cta.CallToActionName}"
              cta-button-type="${cta.CallToActionType}"
              cta-button-action="${cta.CallToActionEmail}"
              cta-background-color="#5068a8"
            >
            <div class="cta-button" ${defaultConstraints}>
              <i class="fas fa-envelope" ${defaultConstraints}></i>
              <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
            </div>
            <div class="cta-label" ${defaultConstraints}>${cta.CallToActionName}</div>
            </div>
            `;
            ctaItem.onclick = (e) => {
              e.preventDefault();
              const emailCtaButton = this.editorManager.editor
                .getWrapper()
                .find(".cta-button-container")[0];

              if (emailCtaButton) {
                const existingComponent = emailCtaButton.find(
                  ".cta-container-child .fas.fa-envelope"
                )[0];

                if (existingComponent) {
                  const message =
                    this.currentLanguage.getTranslation("cta_button_exists");
                  this.displayAlertMessage(message, "error");
                  return; // Exit if the component already exists
                }
                emailCtaButton.append(emailComponent);
              }
            };
            break;

          case "SiteUrl":
            iconHtml = '<i class="fa fa-link"></i>';
            const websiteComponent = `
            <div class="cta-container-child cta-child" 
              data-gjs-draggable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              cta-button-label-id="${cta.CallToActionId}"
              cta-button-label="${cta.CallToActionName}"
              cta-button-type="${cta.CallToActionType}"
              cta-button-action="${cta.CallToActionUrl}"
              cta-background-color="#5068a8"
            >
              <div class="cta-button" ${defaultConstraints}>
                <i class="fas fa-link" ${defaultConstraints}></i>
                <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
              </div>
              <div class="cta-label" ${defaultConstraints}>${cta.CallToActionName}</div>
              </div>
            `;
            ctaItem.onclick = (e) => {
              e.preventDefault();
              const websiteLinkComponent = this.editorManager.editor
                .getWrapper()
                .find(".cta-button-container")[0];

              if (websiteLinkComponent) {
                const existingComponent = websiteLinkComponent.find(
                  ".cta-container-child .fas.fa-link"
                )[0];

                if (existingComponent) {
                  const message =
                    this.currentLanguage.getTranslation("cta_button_exists");
                  this.displayAlertMessage(message, "error");
                  return; // Exit if the component already exists
                }
                websiteLinkComponent.append(websiteComponent);
              }
            };
            break;

          case "Form":
            iconHtml = '<i class="fa fa-file"></i>';
            const formComponent = `
            <div class="cta-container-child cta-child" 
              data-gjs-draggable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              cta-button-label-id="${cta.CallToActionId}"
              cta-button-label="${cta.CallToActionName}"
              cta-button-type="${cta.CallToActionType}"
              cta-button-action="${cta.CallToActionUrl}"
              cta-background-color="#5068a8"
            >
              <div class="cta-button" ${defaultConstraints}>
                <i class="fas fa-file" ${defaultConstraints}></i>
                <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
              </div>
              <div class="cta-label" ${defaultConstraints}>${cta.CallToActionName}</div>
              </div>
            `;
            ctaItem.onclick = (e) => {
              e.preventDefault();
              const formLinkComponent = this.editorManager.editor
                .getWrapper()
                .find(".cta-button-container")[0];

              if (formLinkComponent) {
                const existingComponent = formLinkComponent.find(
                  ".cta-container-child .fas.fa-file"
                )[0];

                if (existingComponent) {
                  const message =
                    this.currentLanguage.getTranslation("cta_button_exists");
                  this.displayAlertMessage(message, "error");
                  return; // Exit if the component already exists
                }
                formLinkComponent.append(formComponent);
              }
            };
            break;

          default:
            iconHtml = '<i class="fa fa-question"></i>';
            ctaItem.onclick = (e) => {
              e.preventDefault();
              console.error(`Unknown action type for ${cta.CallToActionName}`);
            };
        }

        ctaItem.innerHTML = `${iconHtml}`;
        contentPageCtas.appendChild(ctaItem);
      });
    };

    renderCtas();

    // handling badge clicks
    const wrapper = this.editorManager.editor.getWrapper();
    wrapper.view.el.addEventListener("click", (e) => {
      const badge = e.target.closest(".cta-badge");
      if (!badge) return;

      e.stopPropagation();

      // First, check if this is a form button (which has a different structure)
      const fullWidthButton = badge.closest(
        ".cta-form-button, .cta-url-button"
      );
      if (fullWidthButton) {
        // For form buttons, we need to remove the container-row
        const containerRow = badge.closest(".container-row");
        if (containerRow) {
          const rowId = containerRow.getAttribute("id");
          const component = this.editorManager.editor
            .getWrapper()
            .find(`#${rowId}`)[0];
          if (component) {
            component.remove();
          }
        }
        return;
      }

      // For regular CTA buttons (email/phone)
      const ctaChild = badge.closest(".cta-container-child");
      if (ctaChild) {
        // Check if this is the last child in the container
        const parentContainer = ctaChild.closest(".cta-button-container");
        const childId = ctaChild.getAttribute("id");
        const component = this.editorManager.editor
          .getWrapper()
          .find(`#${childId}`)[0];

        if (component) {
          component.remove();
        }
      }
    });
  }

  setupColorRadios(radioGroup, colorValues, type) {
    Object.keys(colorValues).forEach((colorKey, index) => {
      const radio = radioGroup[index];
      const colorValue = colorValues[colorKey];

      const colorBox = radio.nextElementSibling;
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-bgcolor", colorValue);

      radio.onclick = () => {
        // Uncheck other radio buttons in the group
        radioGroup.forEach((r) => (r.checked = false));
        radio.checked = true;

        // Apply the color based on type
        if (type === "text") {
          this.editorManager.selectedComponent.addStyle({
            color: colorValue,
          });
          this.setAttributeToSelected("tile-text-color", colorValue);
        } else if (type === "icon") {
          const svgIcon = this.editorManager.editor
            .getSelected()
            .find(".tile-icon path")[0];
          if (svgIcon) {
            svgIcon.removeAttributes("fill");
            svgIcon.addAttributes({ fill: colorValue });
            this.setAttributeToSelected("tile-icon-color", colorValue);
          } else {
            const message = this.currentLanguage.getTranslation(
              "no_icon_selected_error_message"
            );
            this.displayAlertMessage(message, "error");
          }
        }
      };
    });
  }

  loadThemeIcons(themeIconsList) {
    console.log("Icons: ", themeIconsList);
    const themeIcons = document.getElementById("icons-list");
    const themeIconCategory = document.getElementById("theme_icon_category");

    // Set default category
    let selectedCategory = "General";

    // Add event listener for category changes
    themeIconCategory.addEventListener("change", (e) => {
      selectedCategory = e.target.value;
      renderIcons();
    });

    const renderIcons = () => {
      // Clear existing icons
      themeIcons.innerHTML = "";

      console.log("Selected Category:", selectedCategory); // Log selected category
      console.log("Theme Icons List:", themeIconsList); // Log the icons list

      // Filter icons based on selected category
      const filteredIcons = themeIconsList.filter(
        (icon) => icon.IconCategory.trim() === selectedCategory.trim()
      );

      console.log("Filtered Icons:", filteredIcons); // Log the filtered icons

      if (filteredIcons.length === 0) {
        console.log("No icons found for selected category.");
      }
      // Render filtered icons
      filteredIcons.forEach((icon) => {
        const iconItem = document.createElement("div");
        iconItem.classList.add("icon");
        iconItem.title = icon.name;

        const displayName =
          icon.IconName.length > 7
            ? icon.IconName.slice(0, 7) + "..."
            : icon.IconName;

        iconItem.innerHTML = `
                ${icon.IconSVG}
                <span class="icon-title">${displayName}</span>
            `;

        iconItem.onclick = () => {
          if (this.editorManager.selectedTemplateWrapper) {
            const templateBlock =
              this.editorManager.selectedTemplateWrapper.querySelector(
                ".template-block"
              );

            if (templateBlock) {
              const iconComponent = this.editorManager.editor
                .getSelected()
                .find(".tile-icon")[0];

              if (iconComponent) {
                iconComponent.components(icon.IconSVG);
                this.setAttributeToSelected("tile-icon", icon.IconSVG);
              }
            } else {
              const message = this.currentLanguage.getTranslation(
                "no_tile_selected_error_message"
              );
              const status = "error";
              this.displayAlertMessage(message, status);
            }
          } else {
            const message = this.currentLanguage.getTranslation(
              "no_tile_selected_error_message"
            );
            const status = "error";
            this.displayAlertMessage(message, status);
          }
        };

        themeIcons.appendChild(iconItem);
      });
    };

    // Initial render with default category
    renderIcons();
  }

  loadPageTemplates() {
    const pageTemplates = document.getElementById("page-templates");
    this.templates.forEach((template, index) => {
      const blockElement = document.createElement("div");

      blockElement.className = "page-template-wrapper"; // Wrapper class for each template block
      // Create the number element
      const numberElement = document.createElement("div");
      numberElement.className = "page-template-block-number";
      numberElement.textContent = index + 1; // Set the number
      const templateBlock = document.createElement("div");
      templateBlock.className = "page-template-block";
      templateBlock.title = "Click to load template"; //
      templateBlock.innerHTML = `<div>${template.media}</div>`;

      blockElement.addEventListener("click", () => {
        const popup = this.popupModal();
        document.body.appendChild(popup);
        popup.style.display = "flex";

        const closeButton = popup.querySelector(".close");
        closeButton.onclick = () => {
          popup.style.display = "none";
          document.body.removeChild(popup);
        };

        const cancelBtn = popup.querySelector("#close_popup");
        cancelBtn.onclick = () => {
          popup.style.display = "none";
          document.body.removeChild(popup);
        };

        const acceptBtn = popup.querySelector("#accept_popup");
        acceptBtn.onclick = () => {
          popup.style.display = "none";
          document.body.removeChild(popup);
          this.editorManager.addFreshTemplate(template.content);
        };
      });

      // Append number and template block to the wrapper
      blockElement.appendChild(numberElement);
      blockElement.appendChild(templateBlock);
      pageTemplates.appendChild(blockElement);
    });
  }

  popupModal() {
    const popup = document.createElement("div");
    popup.className = "popup-modal";
    popup.innerHTML = `
      <div class="popup">
        <div class="popup-header">
          <span>${this.currentLanguage.getTranslation(
            "confirmation_modal_title"
          )}</span>
          <button class="close">
            <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
            </svg>
          </button>
        </div>
        <hr>
        <div class="popup-body" id="confirmation_modal_message">
          ${this.currentLanguage.getTranslation("confirmation_modal_message")}
        </div>
        <div class="popup-footer">
          <button id="accept_popup" class="toolbox-btn toolbox-btn-primary">
          ${this.currentLanguage.getTranslation("accept_popup")}
          </button>
          <button id="close_popup" class="toolbox-btn toolbox-btn-outline">
          ${this.currentLanguage.getTranslation("cancel_btn")}
          </button>
        </div>
      </div>
    `;

    return popup;
  }
  displayAlertMessage(message, status) {
    const alertContainer = document.getElementById("alerts-container");

    const alertId = Math.random().toString(10);

    const alertBox = this.alertMessage(message, status, alertId);
    alertBox.style.display = "flex";

    const closeButton = alertBox.querySelector(".alert-close-btn");
    closeButton.addEventListener("click", () => {
      this.closeAlert(alertId);
    });

    setTimeout(() => this.closeAlert(alertId), 5000);
    alertContainer.appendChild(alertBox);
  }
  alertMessage(message, status, alertId) {
    const alertBox = document.createElement("div");
    alertBox.id = alertId;
    alertBox.classList = `alert ${status == "success" ? "success" : "error"}`;
    alertBox.innerHTML = `
      <div class="alert-header">
        <strong>
          ${
            status == "success"
              ? this.currentLanguage.getTranslation("alert_type_success")
              : this.currentLanguage.getTranslation("alert_type_error")
          }
        </strong>
        <span class="alert-close-btn">✖</span>
      </div>
      <p>${message}</p>
    `;

    return alertBox;
  }

  closeAlert(alertId) {
    const alert = document.getElementById(alertId);
    if (alert) {
      alert.style.opacity = 0;
      setTimeout(() => alert.remove(), 500);
    }
  }

  setAttributeToSelected(attributeName, attributeValue) {
    if (this.editorManager.editor.getSelected()) {
      this.editorManager.editor
        .getSelected()
        .addAttributes({ [attributeName]: attributeValue });
    } else {
      this.displayAlertMessage(
        this.currentLanguage.getTranslation("no_tile_selected_error_message"),
        "error"
      );
    }
  }

  updateTileProperties(editor) {
    // Combined alignment checker
    const alignmentTypes = [
      { type: "text", attribute: "tile-text-align" },
      { type: "icon", attribute: "tile-icon-align" },
    ];

    alignmentTypes.forEach(({ type, attribute }) => {
      const currentAlign = editor.getSelected()?.getAttributes()?.[attribute];
      ["left", "center", "right"].forEach((align) => {
        document.getElementById(`${type}-align-${align}`).checked =
          currentAlign === align;
      });
    });

    const currentTextColor = editor.getSelected()?.getAttributes()?.[
      "tile-text-color"
    ];
    const textColorRadios = document.querySelectorAll(
      '.text-color-palette.text-colors .color-item input[type="radio"]' // Added .text-colors
    );

    textColorRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-text-color") === currentTextColor;
    });

    // Update tile icon color
    const currentIconColor = editor.getSelected()?.getAttributes()?.[
      "tile-icon-color"
    ];
    const iconColorRadios = document.querySelectorAll(
      '.text-color-palette.icon-colors .color-item input[type="radio"]' // Added .icon-colors
    );

    iconColorRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-icon-color") === currentIconColor;
    });

    // update tile bg color
    const currentBgColor = editor.getSelected()?.getAttributes()?.[
      "tile-bgcolor"
    ];
    const radios = document.querySelectorAll(
      '#theme-color-palette input[type="radio"]'
    );

    radios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-bgcolor") === currentBgColor;
    });

    // update cta button bg color
    const currentCtaBgColor = editor.getSelected()?.getAttributes()?.[
      "cta-background-color"
    ];
    const CtaRadios = document.querySelectorAll(
      '#cta-color-palette input[type="radio"]'
    );

    CtaRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-cta-color") === currentCtaBgColor;
    });

    // update action
    const currentActionName = editor.getSelected()?.getAttributes()?.[
      "tile-action-object"
    ];

    const currentActionId = editor.getSelected()?.getAttributes()?.[
      "tile-action-object-id"
    ];

    const propertySection = document.getElementById("selectedOption");
    const selectedOptionElement = document.getElementById(currentActionId);

    // Clear background styles for all options
    const allOptions = document.querySelectorAll(".category-content li");
    allOptions.forEach((option) => {
      option.style.background = ""; // Clear any existing background styles
    });

    if (currentActionName && currentActionId && selectedOptionElement) {
      propertySection.textContent = currentActionName;
      propertySection.innerHTML += ' <i class="fa fa-angle-down"></i>';

      // Set background style for the selected option
      selectedOptionElement.style.background = "#f0f0f0";
    }
  }

  resetPropertySection() {
    const themeSection = document.querySelector(".theme-section");
    const titleSection = document.querySelector(".title-section");
    const customSelectContainer = document.querySelector(
      ".custom-select-container"
    );
    const servicesSection = document.querySelector(".services-section");
    const contentPageSection = document.querySelector(".content-page-section");

    if (themeSection) themeSection.style.display = "block";
    if (titleSection) titleSection.style.display = "block";
    if (customSelectContainer) customSelectContainer.style.display = "block";
    if (servicesSection) servicesSection.style.display = "block";
    if (contentPageSection) contentPageSection.style.display = "none";
  }

  updatePropertySection() {
    const themeSection = document.querySelector(".theme-section");
    const titleSection = document.querySelector(".title-section");
    const customSelectContainer = document.querySelector(
      ".custom-select-container"
    );
    const servicesSection = document.querySelector(".services-section");
    const contentPageSection = document.querySelector(".content-page-section");

    if (themeSection) themeSection.style.display = "none";
    if (titleSection) titleSection.style.display = "none";
    if (customSelectContainer) customSelectContainer.style.display = "none";
    if (servicesSection) servicesSection.style.display = "none";
    if (contentPageSection) contentPageSection.style.display = "block";
  }
}

class PagesManager {
  constructor(editor) {
    this.editor = [];
    this.selectedPageId = null;
  }
}

class Clock {
  constructor() {
    this.updateTime();
    setInterval(() => this.updateTime(), 60000); // Update time every minute
  }

  updateTime() {
    const now = new Date();
    let hours = now.getHours();
    const minutes = now.getMinutes().toString().padStart(2, "0");
    const ampm = hours >= 12 ? "PM" : "AM";
    hours = hours % 12;
    hours = hours ? hours : 12; // Adjust hours for 12-hour format
    const timeString = `${hours}:${minutes}`;
    document.getElementById("current-time").textContent = timeString;
  }
}
