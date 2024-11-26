var globalEditor = null;

class EditorManager {
  // muti editors
  editors = []

  childEditors = []
  childPageIds = []

  currentEditorIndex = 1
  editorsContainer = document.getElementById('editors-container')

  editors = {}

  constructor(editor, currentLanguage) {
    globalEditor = editor;
    this.editor = editor;
    this.selectedTemplateWrapper = null;
    this.selectedComponent = null;
    this.templateComponent = null;
    this.isResizing = false;
    this.currentResizer = null;
    this.initialX = null;
    this.initialWidth = null;
    this.currentLanguage = currentLanguage;
    this.pageId = this.getCurrentPageId();
    this.pageName = "Home";
    this.toolsSection = null;
    this.dataManager = null;
    this.editors['Home'] = editor
    let homePageFrame =  document.getElementById('homePageFrame')
    homePageFrame.addEventListener('click', (event)=>{
      this.toolsSection.editorManager.editor = this.editors[0]
      this.editor = this.editors['Home']
      console.log(this.editor)
      alert(event)
    })
  }

  setToolsSection(toolBox) {
    this.toolsSection = toolBox;
  }

  setDataManager(dataManager) {
    this.dataManager = dataManager;
  }

  renderChildEditors(){
    // remove all child editors
    while (this.editorsContainer.children.length > 1) {
      this.editorsContainer.removeChild(this.editorsContainer.children[1]);
    }
    //this.editors = this.editors.slice(1, this.editors.length)

    for (let index = 0; index < this.childPageIds.length; index++) {
      const PageId = this.childPageIds[index];
      let frameHTML = `
          <div class="header">
              <span id="current-time"></span>
              <span class="icons">
              <i class="fas fa-signal"></i>
              <i class="fas fa-wifi"></i>
              <i class="fas fa-battery"></i>
              </span>
          </div>
          <div id="gjs-${index}">${PageId}</div>
      `
      let div = document.createElement('div')
      div.classList.add('mobile-frame')
      div.id = PageId
      div.innerHTML = frameHTML
      
      div.addEventListener('click', ()=>{
        console.log('mouse over '+index)
        console.log(this.editors)
        this.toolsSection.editorManager.editor = this.editors[PageId]
        this.editor = this.editors[PageId]
        console.log(this.editor)
      })
      
      this.editorsContainer.appendChild(div)



      // create editor
      let editor = initEditor(index)
      let page = this.dataManager.pages.find(page=>page.PageId==PageId)
      if(page){
        editor.loadProjectData(JSON.parse(page.PageGJSJson))
        this.editors[PageId] = editor
      }
      console.log(this.editors)
    }

  }

  init() {
    this.editor.on("load", () => {
      
      this.toolsSection.resetPropertySection();

      // Define wrapper event handler setup as a separate function
      const setupWrapperEvents = () => {
        const wrapper = this.editor.getWrapper();
        if (!wrapper || !wrapper.view || !wrapper.view.el) return;

        // Remove existing event listener if it exists
        if (this.wrapperClickHandler) {
          wrapper.view.el.removeEventListener(
            "click",
            this.wrapperClickHandler
          );
        }

        // Define the event handler
        this.wrapperClickHandler = (e) => {
          const button = e.target.closest(".action-button");
          if (!button) return;

          const templateWrapper = button.closest(".template-wrapper");
          if (!templateWrapper) return;

          this.templateComponent = this.editor.Components.getById(
            templateWrapper.id
          );
          if (!this.templateComponent) return;

          if (button.classList.contains("delete-button")) {
            this.deleteTemplate(this.templateComponent);
          } else if (button.classList.contains("add-button-bottom")) {
            this.addTemplateBottom(this.templateComponent);
          } else if (button.classList.contains("add-button-right")) {
            this.addTemplateRight(this.templateComponent);
          }
        };

        // Add the click event listener
        wrapper.view.el.addEventListener("click", this.wrapperClickHandler);

        // Set wrapper properties
        wrapper.set({
          selectable: false,
          droppable: false,
          resizable: {
            handles: "e",
          },
        });
      };

      // Fetch page data directly
      this.dataManager
        .getSinglePage(this.getCurrentPageId())
        .then((pageData) => {
          console.log("Page Data is: ", pageData);
          if (pageData && pageData.PageGJSJson) {
            
            let parsedData;
            try {
              parsedData = JSON.parse(pageData.PageGJSJson);
              if (!parsedData.pages) {
                parsedData = {
                  pages: [
                    {
                      component: parsedData,
                      frames: [
                        {
                          component: parsedData,
                        },
                      ],
                    },
                  ],
                };
              }

              if (pageData.PageIsContentPage) {
                this.dataManager
                  .getContentPageData(this.getCurrentPageId())
                  .then((contentPageData) => {
                    if (contentPageData) {
                      this.toolsSection.pageContentCtas(
                        contentPageData.CallToActions
                      );
                    }
                  })
                  .catch((error) => {
                    console.error("Error fetching content page data:", error);
                  });
                this.toolsSection.updatePropertySection();
              }

              // Load project data and setup events after loading
              console.log('parsedData', parsedData)
              this.editor.loadProjectData(parsedData);

              // Setup wrapper events after project data is loaded
              this.editor.once("load:components", () => {
                setupWrapperEvents();
              });
            } catch (error) {
              const message = this.currentLanguage.getTranslation(
                "no_icon_selected_error_message"
              );
              const status = "error";
              this.toolsSection.displayAlertMessage(message, status);
            }
          } else if (pageData && pageData.PageIsContentPage) {
            this.dataManager
              .getContentPageData(this.getCurrentPageId())
              .then((contentPageData) => {
                if (contentPageData) {
                  this.initialContentPageTemplate(contentPageData);
                  this.toolsSection.pageContentCtas(
                    contentPageData.CallToActions
                  );
                }
              })
              .catch((error) => {
                console.error("Error fetching content page data:", error);
              });
            this.toolsSection.updatePropertySection();
          } else {
            this.initialTemplate();
          }

          // Setup wrapper events after all operations
          setupWrapperEvents();
          this.rightClickEventHandler();
        })
        .catch((error) => {
          console.error("Error fetching page data:", error);
        });
    });

    this.editor.on("component:selected", (component) => {
      this.selectedTemplateWrapper = component.getEl();
      this.selectedComponent = component;
      const sidebarInputTitle = document.getElementById("tile-title");
      if (this.selectedTemplateWrapper) {
        const tileLabel =
          this.selectedTemplateWrapper.querySelector(".tile-title");
        if (tileLabel) {
          sidebarInputTitle.value = tileLabel.textContent;
        }

        // remove tile icon
        const closeIconSection = this.editor
          .getSelected()
          .find(".selected-tile-icon")[0];
        if (closeIconSection) {
          const closeIconEl = closeIconSection.getEl();

          if (closeIconEl) {
            closeIconEl.onclick = () => {
              this.editor.getSelected().find(".tile-icon-section")[0].remove();
            };
          } else {
            console.warn("DOM element not found for selected-tile-icon");
          }
        }

        // remove tile title
        const closeTitleSection = this.editor
          .getSelected()
          .find(".selected-tile-title")[0];
        if (closeTitleSection) {
          const closeTitleEl = closeTitleSection.getEl();

          if (closeTitleEl) {
            closeTitleEl.onclick = () => {
              this.editor.getSelected().find(".tile-title-section")[0].remove();
            };
          } else {
            console.warn("DOM element not found for selected-tile-icon");
          }
        }

        document.querySelector(`#templates-button`).classList.remove("active");
        document.querySelector(`#pages-button`).classList.remove("active");
        document.querySelector(`#pages-button`).classList.add("active");
        document.querySelector(`#mapping-section`).style.display = "none";
        document.querySelector(`#tools-section`).style.display = "block";

        document
          .querySelector(`#templates-content`)
          .classList.remove("active-tab");
        document.querySelector(`#pages-content`).classList.add("active-tab");
      }

      this.toolsSection.updateTileProperties(this.editor);
      // hide context menu if any
      const contextMenu = document.getElementById("contextMenu");

      if (contextMenu) {
        contextMenu.style.display = "none";
      }

      let nextPageId = component.attributes.attributes["tile-action-object-id"]
      this.childPageIds = []
      this.childPageIds.push(nextPageId)
      if (nextPageId) {
        console.log(this.childPageIds)
        this.renderChildEditors()
      }
    });

    // Listen for component drag start and change the cursor
    this.editor.on("component:drag:start", (component) => {
      const iframe = document.querySelector("#gjs iframe");
      const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
      iframeDoc.body.style.cursor = "grabbing";
    });

    // Listen for component drag end and reset the cursor
    this.editor.on("component:drag:end", (component) => {
      const iframe = document.querySelector("#gjs iframe");
      const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
      iframeDoc.body.style.cursor = "";
    });

    const sidebarInputTitle = document.getElementById("tile-title");

    sidebarInputTitle.addEventListener("input", (e) => {
      this.updateTileTitle(e.target.value);
    });

    const frameEl = this.editor.Canvas.getFrameEl();
    frameEl.contentDocument.addEventListener("mousedown", this.initResize);
    frameEl.contentDocument.addEventListener("mousemove", this.resize);
    frameEl.contentDocument.addEventListener("mouseup", this.stopResize);

    //auto save page every 2 seconds
    // setInterval(() => {
    //   this.saveCurrentPage();
    // }, 2000);
  }

  updateTileTitle(inputTitle) {
    if (this.selectedTemplateWrapper) {
      const titleComponent = this.editor.getSelected().find(".tile-title")[0];
      if (titleComponent) {
        titleComponent.components(inputTitle);
        this.editor.getSelected().addAttributes({ "tile-title": inputTitle });
      }
    }
  }

  getSelectedTemplateWrapper() {
    return this.selectedTemplateWrapper;
  }

  getSelectedComponent() {
    return this.selectedComponent;
  }

  setCurrentPage(page) {
    localStorage.setItem("pageId", page.PageId);
    localStorage.setItem("pageName", page.PageName);
    const localStorageKey = `page-${page.PageId}`;
    localStorage.setItem(localStorageKey, page.PageGJSJson);
  }

  setCurrentPageId(pageId) {
    localStorage.setItem("pageId", pageId);
  }

  getCurrentPageId() {
    return localStorage.getItem("pageId");
  }

  getCurrentPageName() {
    return this.pageName;
  }

  setCurrentPageName(pageName) {
    this.pageName = pageName;
    localStorage.setItem("pageName", pageName);
  }

  addFreshTemplate(template) {
    this.editor.DomComponents.clear();
    let fullTemplate = "";

    template.forEach((columns) => {
      const templateRow = this.generateTemplateRow(columns);
      fullTemplate += templateRow;
    });

    this.editor.addComponents(`
        <div class="frame-container"
             id="frame-container"
             data-gjs-type="template-wrapper"
             data-gjs-draggable="false"
             data-gjs-selectable="false"
             data-gjs-editable="false"
             data-gjs-highlightable="false"
             data-gjs-droppable="false"
             data-gjs-hoverable="false">
          <div class="container-column"
               data-gjs-type="template-wrapper"
               data-gjs-draggable="false"
               data-gjs-selectable="false"
               data-gjs-editable="false"
               data-gjs-highlightable="false"
               data-gjs-droppable="false"
               data-gjs-hoverable="false">
              ${fullTemplate}
          </div>
        </div>
        `);

    const message = this.currentLanguage.getTranslation(
      "template_added_success_message"
    );
    const status = "success";
    this.toolsSection.displayAlertMessage(message, status);
  }

  initialTemplate() {
    return this.editor.addComponents(`
        <div class="frame-container"
             id="frame-container"
             data-gjs-type="template-wrapper"
             data-gjs-draggable="false"
             data-gjs-selectable="false"
             data-gjs-editable="false"
             data-gjs-highlightable="false"
             data-gjs-droppable="false"
             data-gjs-hoverable="false">
          <div class="container-column"
               data-gjs-type="template-wrapper"
               data-gjs-draggable="false"
               data-gjs-selectable="false"
               data-gjs-editable="false"
               data-gjs-highlightable="false"
               data-gjs-droppable="false"
               data-gjs-hoverable="false">
            <div class="container-row"
                 data-gjs-type="template-wrapper"
                 data-gjs-draggable="false"
                 data-gjs-selectable="false"
                 data-gjs-editable="false"
                 data-gjs-highlightable="true"
                 data-gjs-hoverable="true">
              ${this.createTemplateHTML(true)}
            </div>
          </div>
        </div>
      `)[0];
  }

  initialContentPageTemplate(contentPageData) {
    return this.editor.addComponents(`
      <div
        class="frame-container"
        id="frame-container"
        data-gjs-type="template-wrapper"
        data-gjs-draggable="false"
        data-gjs-selectable="false"
        data-gjs-editable="false"
        data-gjs-highlightable="false"
        data-gjs-droppable="false"
        data-gjs-hoverable="false"
      >
        <div
          class="container-column"
          data-gjs-type="template-wrapper"
          data-gjs-draggable="false"
          data-gjs-selectable="false"
          data-gjs-editable="false"
          data-gjs-highlightable="false"
          data-gjs-droppable="true"
          data-gjs-hoverable="false"
        >
          <div
            class="container-row"
            data-gjs-type="template-wrapper"
            data-gjs-draggable="true"
            data-gjs-selectable="false"
            data-gjs-editable="false"
            data-gjs-droppable="false"
            data-gjs-highlightable="true"
            data-gjs-hoverable="true"
          >
            <div
              class="template-wrapper"
              data-gjs-type="template-wrapper"
              data-gjs-draggable="false"
              data-gjs-selectable="false"
              data-gjs-editable="false"
              data-gjs-droppable="false"
              data-gjs-highlightable="true"
              data-gjs-hoverable="true"
              style="display: flex; width: 100%"
            >
              <div
                class="template-block"
                data-gjs-draggable="false"
                data-gjs-selectable="false"
                data-gjs-editable="false"
                data-gjs-highlightable="false"
                data-gjs-droppable="false"
                data-gjs-resizable="false"
                data-gjs-hoverable="false"
                style="flex: 1; padding: 0"
              >
                <img
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false"
                  src="${contentPageData.ProductServiceImage}"
                  style="width: 100%; height: 100%; object-fit: cover"
                  alt="Full-width Image"
                />
              </div>
            </div>
          </div>

          <div
            class="container-row"
            data-gjs-type="template-wrapper"
            data-gjs-draggable="true"
            data-gjs-selectable="false"
            data-gjs-editable="false"
            data-gjs-droppable="false"
            data-gjs-highlightable="true"
            data-gjs-hoverable="true"
          >
            <div
              class="template-wrapper"
              data-gjs-type="template-wrapper"
              data-gjs-draggable="false"
              data-gjs-selectable="false"
              data-gjs-editable="false"
              data-gjs-droppable="false"
              data-gjs-highlightable="true"
              data-gjs-hoverable="true"
              style="display: flex; width: 100%"
            >
              <div
                class="template-block"
                data-gjs-draggable="false"
                data-gjs-selectable="false"
                data-gjs-editable="false"
                data-gjs-highlightable="false"
                data-gjs-droppable="false"
                data-gjs-resizable="false"
                data-gjs-hoverable="false"
                style="flex: 1; padding: 0; height: auto"
              >
                <p
                  style="margin: 0"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false"
                >
                ${contentPageData.ProductServiceDescription}
                </p>
              </div>
            </div>
          </div>
          <div class="cta-button-container" ${defaultConstraints}></div>      
        </div>
      </div>

    `)[0];
  }

  createTemplateHTML(isDefault = false) {
    return `
        <div ${defaultTileAttrs} class="template-wrapper ${
      isDefault ? "default-template" : ""
    }"
              data-gjs-type="template-wrapper"
              data-gjs-droppable="false">
          <div class="template-block"
             data-gjs-draggable="false"
             data-gjs-selectable="false"
             data-gjs-editable="false"
             data-gjs-highlightable="false"
             data-gjs-droppable="false"
             data-gjs-resizable="false"
             data-gjs-hoverable="false">
            
             <div class="tile-icon-section"
              data-gjs-draggable="false"
              data-gjs-selectable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              >
                <span class="tile-close-icon top-right selected-tile-icon"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false"
                  >&times;</span>
                <span 
                  class="tile-icon"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false">
                </span>
            </div>
            <div class="tile-title-section"
              data-gjs-draggable="false"
              data-gjs-selectable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-resizable="false"
              data-gjs-hoverable="false"
              >
                <span class="tile-close-icon top-right selected-tile-title"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false"
                  >&times;</span>
                <span 
                  class="tile-title"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false">Title</span>
                </div>
            </div>
          ${
            !isDefault
              ? `
            <button class="action-button delete-button" title="Delete template"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                <line x1="5" y1="12" x2="19" y2="12" 
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false"/>
              </svg>
            </button>
          `
              : ""
          }
          <button class="action-button add-button-bottom" title="Add template below"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-droppable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false">
              <line x1="12" y1="5" x2="12" y2="19" 
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false"/>
              <line x1="5" y1="12" x2="19" y2="12" 
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false"/>
            </svg>
          </button>
          <button class="action-button add-button-right" title="Add template right"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-droppable="false"
                  data-gjs-highlightable="false"
                  data-gjs-hoverable="false">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false">
              <line x1="12" y1="5" x2="12" y2="19" 
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false"/>
              <line x1="5" y1="12" x2="19" y2="12" 
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false"/>
            </svg>
          </button>
          <div class="resize-handle"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-hoverable="false">
          </div>
        </div>
      `;
  }

  generateTemplateRow(columns) {
    let columnWidth = 100 / columns;
    if (columns === 1) {
      columnWidth = 100;
    } else if (columns === 2) {
      columnWidth = 49;
    } else if (columns === 3) {
      columnWidth = 32;
    }

    let wrappers = "";

    for (let i = 0; i < columns; i++) {
      wrappers += `
        <div class="template-wrapper"
                  ${defaultTileAttrs}
                  style="flex: 0 0 ${columnWidth}%);"
                  data-gjs-type="template-wrapper"
                  data-gjs-droppable="false">
                  <div class="template-block"
                    data-gjs-draggable="false"
                    data-gjs-selectable="false"
                    data-gjs-editable="false"
                    data-gjs-highlightable="false"
                    data-gjs-droppable="false"
                    data-gjs-resizable="false"
                    data-gjs-hoverable="false">
                    
                    <div class="tile-icon-section"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-resizable="false"
                      data-gjs-hoverable="false"
                      >
                        <span class="tile-close-icon top-right selected-tile-icon"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-resizable="false"
                          data-gjs-hoverable="false"
                          >&times;</span>
                        <span 
                          class="tile-icon"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-droppable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false">
                        </span>
                    </div>
                    <div class="tile-title-section"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-resizable="false"
                      data-gjs-hoverable="false"
                      >
                        <span class="tile-close-icon top-right selected-tile-title"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-resizable="false"
                          data-gjs-hoverable="false"
                          >&times;</span>
                        <span 
                          class="tile-title"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-droppable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false">Title</span>
                        </div>
                  </div>
                  <button class="action-button delete-button" title="Delete template"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                      <line x1="5" y1="12" x2="19" y2="12" 
                        data-gjs-draggable="false"
                        data-gjs-selectable="false"
                        data-gjs-editable="false"
                        data-gjs-highlightable="false"
                        data-gjs-droppable="false"
                        data-gjs-hoverable="false"/>
                    </svg>
                  </button>
                  <button class="action-button add-button-bottom" title="Add template below"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-droppable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false"
                          >
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false">
                      <line x1="12" y1="5" x2="12" y2="19" 
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false"/>
                      <line x1="5" y1="12" x2="19" y2="12" 
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false"/>
                    </svg>
                  </button>
                  <button class="action-button add-button-right" title="Add template right"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-droppable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false">
                      <line x1="12" y1="5" x2="12" y2="19" 
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false"/>
                      <line x1="5" y1="12" x2="19" y2="12" 
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="false"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="false"/>
                    </svg>
                  </button>
                  <div class="resize-handle"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false">
                  </div>
              </div>
        `;
    }
    return `
              <div class="container-row"
                  data-gjs-type="template-wrapper"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="true"
                  data-gjs-hoverable="true">
                ${wrappers}
            </div>
      `;
  }

  initResize(e) {
    const resizer = e.target.closest(".resize-handle");
    if (!resizer) return;

    const templateWrapper = resizer.closest(".template-wrapper");
    const containerRow = templateWrapper.parentElement;
    if (!containerRow) return;

    const templates = Array.from(containerRow.children).filter((child) => {
      child.classList.contains("template-wrapper");
    });
    if (templates.length === 3) return;

    this.isResizing = true;
    this.currentResizer = resizer;

    this.initialWidth = templateWrapper.offsetWidth;
    this.initialX = e.clientX;
  }

  resize(e) {
    if (!this.isResizing) return;

    const templateWrapper = this.currentResizer.closest(".template-wrapper");
    const containerRow = templateWrapper.parentElement;

    if (!containerRow) return;

    const templates = Array.from(containerRow.children).filter((child) => {
      return child.classList.contains("template-wrapper");
    });

    // Stop resizing if there are three templates
    if (templates.length === 3) {
      this.stopResize();
      return;
    }

    const currentIndex = templates.indexOf(templateWrapper);
    const deltaX = e.clientX - this.initialX;
    const containerWidth = containerRow.getBoundingClientRect().width;
    const gap = parseFloat(getComputedStyle(containerRow).gap);
    const availableWidth = containerWidth - gap;
    const step = 100;

    // Calculate the current width percentage
    let newWidth = ((this.initialWidth + deltaX) / availableWidth) * 100;

    // Snap to nearest step of 100px
    newWidth = Math.round(newWidth / step) * step;

    const minWidth = step;
    const maxWidth = templates.length === 2 ? step : 100; // Adjust maximum width for two templates

    if (newWidth < minWidth) {
      newWidth = minWidth;
    } else if (newWidth > maxWidth) {
      newWidth = maxWidth;
    }

    templateWrapper.style.flex = `0 0 ${newWidth}px`;

    if (templates.length === 2) {
      const otherTemplate = templates[currentIndex === 0 ? 1 : 0];
      let otherNewWidth = 100 - newWidth;

      otherNewWidth = Math.round(otherNewWidth / step) * step;
      if (otherNewWidth > 200) {
        otherNewWidth = 200;
      }

      otherTemplate.style.flex = `0 0 calc(${otherNewWidth}px + 0.8rem)`;
    }

    templateWrapper.getBoundingClientRect();
  }

  stopResize() {
    this.isResizing = false;
  }

  updateRightButtons(containerRow) {
    if (!containerRow) return;

    const templates = containerRow.components();
    let totalWidth = 0;
    templates.forEach((template) => {
      if (!template || !template.view || !template.view.el) return;

      const rightButton = template.view.el.querySelector(".add-button-right");
      if (!rightButton) return;
      const rightButtonComponent = template.find(".add-button-right")[0];

      if (templates.length >= 3) {
        rightButton.setAttribute("disabled", "true");
        rightButtonComponent.addStyle({ display: "none" });
      } else {
        rightButton.removeAttribute("disabled");
        rightButtonComponent.addStyle({ display: "flex" });
      }
    });
  }

  addTemplateRight(templateComponent) {
    const containerRow = templateComponent.parent();
    if (!containerRow || containerRow.components().length >= 3) return;
    const newComponents = this.editor.addComponents(this.createTemplateHTML());
    const newTemplate = newComponents[0];
    if (!newTemplate) return;

    const index = templateComponent.index();
    containerRow.append(newTemplate, { at: index + 1 });
    const templates = containerRow.components();

    const equalWidth = 100 / templates.length;
    templates.forEach((template) => {
      template.addStyle({
        flex: `0 0 calc(${equalWidth}% - 0.3.5rem)`,
      });
    });

    this.updateRightButtons(containerRow);
  }

  addTemplateBottom(templateComponent) {
    const currentRow = templateComponent.parent();
    const containerColumn = currentRow?.parent();

    if (!containerColumn) return;

    const newRow = this.editor.addComponents(`
        <div class="container-row"
            data-gjs-type="template-wrapper"
            data-gjs-draggable="false"
            data-gjs-selectable="false"
            data-gjs-editable="false"
            data-gjs-highlightable="false"
            data-gjs-hoverable="false">
          ${this.createTemplateHTML()}
        </div>
      `)[0];

    const index = currentRow.index();
    containerColumn.append(newRow, { at: index + 1 });
  }

  deleteTemplate(templateComponent) {
    if (
      !templateComponent ||
      templateComponent.getClasses().includes("default-template")
    )
      return;

    const containerRow = templateComponent.parent();
    if (!containerRow) return;

    templateComponent.remove();

    // Adjust widths of remaining templates
    const templates = containerRow.components();
    const newWidth = 100 / templates.length;
    templates.forEach((template) => {
      if (template && template.setStyle) {
        template.addStyle({ width: `${newWidth}%` });
      }
    });

    this.updateRightButtons(containerRow);
  }

  saveCurrentPage() {
    const localStorageKey = `page-${this.getCurrentPageId()}`;
    try {
      const data = this.editor.getProjectData();
      localStorage.setItem(localStorageKey, JSON.stringify(data));
      let projectData = this.editor.getProjectData();
      let pageData;

      
      // this.dataManager
      //   .getSinglePage(this.getCurrentPageId())
      //   .then((page) => {
      //     console.log("Page Data is: ", page);
      //     if (page) {
      //       if (page.PageIsContentPage) {
      //         pageData = mapContentToPageData(projectData);
      //       } else {

      //       }
      //     }
      //   });
      
      let pageId = this.getCurrentPageId();
      if (pageId) {
        let data = {
          PageId: pageId,
          PageJsonContent: JSON.stringify(pageData),
          PageGJSHtml: this.editor.getHtml(),
          PageGJSJson: JSON.stringify(projectData),
          SDT_Page: pageData,
          PageIsPublished: true,
        };

        this.toolsSection.dataManager.updatePage(data).then((res) => {
          console.log("Page Save Successfully");
        });
      }
    } catch (error) {
      const message = this.currentLanguage.getTranslation(
        "failed_to_save_current_page_message"
      );
      const status = "error";
      this.toolsSection.displayAlertMessage(message, status);
    }
  }

  rightClickEventHandler() {
    const iframe = document.querySelector("#gjs iframe");
    const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
    const contextMenu = document.getElementById("contextMenu");

    // Helper function to hide context menu
    const hideContextMenu = () => {
      contextMenu.style.display = "none";
    };

    document.addEventListener("click", (e) => {
      if (!contextMenu.contains(e.target)) {
        hideContextMenu();
      }
    });

    iframeDoc.addEventListener("click", () => {
      hideContextMenu();
    });

    // Handle right-click (context menu)
    iframeDoc.addEventListener("contextmenu", (e) => {
      const block = e.target.closest(".template-block");
      if (block) {
        e.preventDefault();

        // Get iframe's position relative to viewport
        const iframeRect = iframe.getBoundingClientRect();

        // Calculate position relative to viewport without scroll position
        const x = e.clientX + iframeRect.left;
        const y = e.clientY + iframeRect.top;

        // Position context menu
        contextMenu.style.position = "fixed";
        contextMenu.style.left = `${x}px`;
        contextMenu.style.top = `${y}px`;
        contextMenu.style.display = "block";

        // Store current block reference
        window.currentBlock = block;
      } else {
        hideContextMenu();
      }
    });

    // Handle delete image action
    const deleteImage = document.getElementById("delete-bg-image");
    deleteImage.addEventListener("click", () => {
      const blockToDelete = window.currentBlock;
      if (blockToDelete) {
        const component = this.editor
          .getWrapper()
          .find('[data-gjs-type="default"]')
          .filter((comp) => comp.getEl() === blockToDelete)[0];

        if (component) {
          component.setStyle({
            "background-image": "",
          });
        } else {
          console.error("Component not found for the block.");
        }

        hideContextMenu();
      }
    });

    // Close context menu on Escape key
    document.addEventListener("keydown", (e) => {
      if (e.key === "Escape") {
        hideContextMenu();
      }
    });
  }
}
