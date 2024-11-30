const environment = "/ComfortaKBDevelopmentNETSQLServer";
let baseURL = window.location.origin;

if (baseURL.startsWith("http://localhost")) baseURL += environment;

let contentPageJson = `
[
  {
    "attributes": {
      "id": "i1im"
    },
    "_undoexc": [
      "status",
      "open"
    ],
    "components": [
      {
        "tagName": "NULL",
        "type": "comment",
        "content": " Image Section ",
        "_undoexc": [
          "status",
          "open"
        ]
      },
      {
        "tagName": "div",
        "type": "image",
        "resizable": {
          "ratioDefault": 1
        },
        "attributes": {
          "id": "itcj",
          "src": "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMDAiIHZpZXdCb3g9IjAgMCAyNCAyNCIgc3R5bGU9ImZpbGw6IHJnYmEoMCwwLDAsMC4xNSk7IHRyYW5zZm9ybTogc2NhbGUoMC43NSkiPgogICAgICAgIDxwYXRoIGQ9Ik04LjUgMTMuNWwyLjUgMyAzLjUtNC41IDQuNSA2SDVtMTYgMVY1YTIgMiAwIDAgMC0yLTJINWMtMS4xIDAtMiAuOS0yIDJ2MTRjMCAxLjEuOSAyIDIgMmgxNGMxLjEgMCAyLS45IDItMnoiPjwvcGF0aD4KICAgICAgPC9zdmc+"
        },
        "_undoexc": [
          "status",
          "open"
        ],
        "components": [
          {
            "type": "image",
            "removable": false,
            "draggable": false,
            "droppable": false,
            "resizable": {
              "ratioDefault": 1
            },
            "editable": false,
            "style": {
              "width": "100%",
              "border-radius": "8px"
            },
            "attributes": {
              "src": "path_to_your_image.png",
              "alt": "Reception Area",
              "style": "width:100%;border-radius:8px;"
            },
            "_undoexc": [
              "status",
              "open"
            ]
          }
        ]
      },
      {
        "tagName": "NULL",
        "type": "comment",
        "content": " Text Section ",
        "_undoexc": [
          "status",
          "open"
        ]
      },
      {
        "type": "text",
        "removable": false,
        "draggable": false,
        "editable": false,
        "attributes": {
          "id": "ipm7"
        },
        "_undoexc": [
          "status",
          "open"
        ],
        "components": [
          {
            "tagName": "p",
            "type": "text",
            "attributes": {
              "id": "i3h9"
            },
            "_undoexc": [
              "status",
              "open"
            ],
            "components": [
              {
                "type": "textnode",
                "content": "Of het nu gaat om technische ondersteuning, informatie over diensten, of algemene vragen, wij zijn er om u te helpen.",
                "_undoexc": [
                  "status",
                  "open"
                ]
              }
            ]
          }
        ]
      },
      {
        "tagName": "NULL",
        "type": "comment",
        "content": " Button Section ",
        "_undoexc": [
          "status",
          "open"
        ]
      },
      {
        "attributes": {
          "id": "iemi6"
        },
        "_undoexc": [
          "status",
          "open"
        ],
        "components": [
          {
            "attributes": {
              "id": "ivtnv"
            },
            "_undoexc": [
              "status",
              "open"
            ],
            "components": [
              {
                "type": "link",
                "editable": false,
                "attributes": {
                  "href": "tel:your_phone_number",
                  "id": "ipkwc"
                },
                "_undoexc": [
                  "status",
                  "open"
                ],
                "components": [
                  {
                    "attributes": {
                      "id": "ihftk"
                    },
                    "_undoexc": [
                      "status",
                      "open"
                    ],
                    "components": [
                      {
                        "tagName": "i",
                        "classes": [
                          "fa",
                          "fa-phone"
                        ],
                        "attributes": {
                          "id": "iq5of"
                        },
                        "_undoexc": [
                          "status",
                          "open"
                        ]
                      }
                    ]
                  },
                  {
                    "tagName": "p",
                    "type": "text",
                    "attributes": {
                      "id": "iojxg"
                    },
                    "_undoexc": [
                      "status",
                      "open"
                    ],
                    "components": [
                      {
                        "type": "textnode",
                        "content": "CALL",
                        "_undoexc": [
                          "status",
                          "open"
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            "attributes": {
              "id": "i1v0y"
            },
            "_undoexc": [
              "status",
              "open"
            ],
            "components": [
              {
                "type": "link",
                "editable": false,
                "attributes": {
                  "href": "mailto:your_email@example.com",
                  "id": "ifduf"
                },
                "_undoexc": [
                  "status",
                  "open"
                ],
                "components": [
                  {
                    "attributes": {
                      "id": "ie7qn"
                    },
                    "_undoexc": [
                      "status",
                      "open"
                    ],
                    "components": [
                      {
                        "tagName": "i",
                        "classes": [
                          "fa",
                          "fa-envelope"
                        ],
                        "attributes": {
                          "id": "iz9g8"
                        },
                        "_undoexc": [
                          "status",
                          "open"
                        ]
                      }
                    ]
                  },
                  {
                    "tagName": "p",
                    "type": "text",
                    "attributes": {
                      "id": "iw4qw"
                    },
                    "_undoexc": [
                      "status",
                      "open"
                    ],
                    "components": [
                      {
                        "type": "textnode",
                        "content": "MAIL",
                        "_undoexc": [
                          "status",
                          "open"
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          }
        ]
      }
    ]
  }
]
`;

let initialPageJson = `
{
  "assets": [],
  "styles": [],
  "pages": [
    {
      "frames": [
        {
          "component": {
            "type": "wrapper",
            "droppable": false,
            "stylable": [
              "background",
              "background-color",
              "background-image",
              "background-repeat",
              "background-attachment",
              "background-position",
              "background-size"
            ],
            "resizable": {
              "handles": "e"
            },
            "selectable": false,
            "_undoexc": [
              "status",
              "open"
            ],
            "components": [
              {
                "type": "template-wrapper",
                "draggable": false,
                "droppable": false,
                "highlightable": false,
                "selectable": false,
                "hoverable": false,
                "classes": [
                  "frame-container"
                ],
                "attributes": {
                  "id": "frame-container"
                },
                "_undoexc": [
                  "status",
                  "open"
                ],
                "components": [
                  {
                    "type": "template-wrapper",
                    "draggable": false,
                    "droppable": false,
                    "highlightable": false,
                    "selectable": false,
                    "hoverable": false,
                    "classes": [
                      "container-column"
                    ],
                    "_undoexc": [
                      "status",
                      "open"
                    ],
                    "components": [
                      {
                        "type": "template-wrapper",
                        "draggable": false,
                        "selectable": false,
                        "classes": [
                          "container-row"
                        ],
                        "_undoexc": [
                          "status",
                          "open"
                        ],
                        "components": [
                          {
                            "type": "template-wrapper",
                            "droppable": false,
                            "classes": [
                              "template-wrapper",
                              "default-template"
                            ],
                            "attributes": {
                              "tile-text": "Tile",
                              "tile-text-color": "#000000",
                              "tile-text-align": "left",
                              "tile-icon": "icon-name",
                              "tile-icon-color": "#000000",
                              "tile-icon-align": "left",
                              "tile-bg-color": "#ffffff",
                              "tile-bg-image": "",
                              "tile-bg-image-opacity": "100",
                              "tile-action-object": "Page",
                              "tile-action-object-id": ""
                            },
                            "_undoexc": [
                              "status",
                              "open"
                            ],
                            "components": [
                              {
                                "draggable": false,
                                "droppable": false,
                                "highlightable": false,
                                "selectable": false,
                                "hoverable": false,
                                "classes": [
                                  "template-block"
                                ],
                                "_undoexc": [
                                  "status",
                                  "open"
                                ],
                                "components": [
                                  {
                                    "draggable": false,
                                    "droppable": false,
                                    "highlightable": false,
                                    "selectable": false,
                                    "hoverable": false,
                                    "classes": [
                                      "tile-icon-section"
                                    ],
                                    "_undoexc": [
                                      "status",
                                      "open"
                                    ],
                                    "components": [
                                      {
                                        "tagName": "span",
                                        "type": "text",
                                        "draggable": false,
                                        "highlightable": false,
                                        "editable": false,
                                        "selectable": false,
                                        "hoverable": false,
                                        "classes": [
                                          "tile-close-icon",
                                          "top-right",
                                          "selected-tile-icon"
                                        ],
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ],
                                        "components": [
                                          {
                                            "type": "textnode",
                                            "content": "×",
                                            "_undoexc": [
                                              "status",
                                              "open"
                                            ]
                                          }
                                        ]
                                      },
                                      {
                                        "tagName": "span",
                                        "type": "text",
                                        "draggable": false,
                                        "highlightable": false,
                                        "editable": false,
                                        "selectable": false,
                                        "hoverable": false,
                                        "classes": [
                                          "tile-icon"
                                        ],
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ],
                                        "components": [
                                          {
                                            "type": "textnode",
                                            "content": "",
                                            "_undoexc": [
                                              "status",
                                              "open"
                                            ]
                                          }
                                        ]
                                      }
                                    ]
                                  },
                                  {
                                    "draggable": false,
                                    "droppable": false,
                                    "highlightable": false,
                                    "selectable": false,
                                    "hoverable": false,
                                    "classes": [
                                      "tile-title-section"
                                    ],
                                    "_undoexc": [
                                      "status",
                                      "open"
                                    ],
                                    "components": [
                                      {
                                        "tagName": "span",
                                        "type": "text",
                                        "draggable": false,
                                        "highlightable": false,
                                        "editable": false,
                                        "selectable": false,
                                        "hoverable": false,
                                        "classes": [
                                          "tile-close-icon",
                                          "top-right",
                                          "selected-tile-title"
                                        ],
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ],
                                        "components": [
                                          {
                                            "type": "textnode",
                                            "content": "×",
                                            "_undoexc": [
                                              "status",
                                              "open"
                                            ]
                                          }
                                        ]
                                      },
                                      {
                                        "tagName": "span",
                                        "type": "text",
                                        "draggable": false,
                                        "highlightable": false,
                                        "editable": false,
                                        "selectable": false,
                                        "hoverable": false,
                                        "classes": [
                                          "tile-title"
                                        ],
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ],
                                        "components": [
                                          {
                                            "type": "textnode",
                                            "content": "Title",
                                            "_undoexc": [
                                              "status",
                                              "open"
                                            ]
                                          }
                                        ]
                                      }
                                    ]
                                  }
                                ]
                              },
                              {
                                "tagName": "button",
                                "draggable": false,
                                "droppable": false,
                                "highlightable": false,
                                "selectable": false,
                                "hoverable": false,
                                "classes": [
                                  "action-button",
                                  "add-button-bottom"
                                ],
                                "attributes": {
                                  "title": "Add template below"
                                },
                                "_undoexc": [
                                  "status",
                                  "open"
                                ],
                                "components": [
                                  {
                                    "type": "svg",
                                    "draggable": false,
                                    "droppable": false,
                                    "highlightable": false,
                                    "resizable": {
                                      "ratioDefault": 1
                                    },
                                    "selectable": false,
                                    "hoverable": false,
                                    "attributes": {
                                      "xmlns": "http://www.w3.org/2000/svg",
                                      "width": "16",
                                      "height": "16",
                                      "viewBox": "0 0 24 24",
                                      "fill": "none",
                                      "stroke": "currentColor",
                                      "stroke-width": "2",
                                      "stroke-linecap": "round",
                                      "stroke-linejoin": "round"
                                    },
                                    "_undoexc": [
                                      "status",
                                      "open"
                                    ],
                                    "components": [
                                      {
                                        "tagName": "line",
                                        "type": "svg-in",
                                        "draggable": false,
                                        "droppable": false,
                                        "highlightable": false,
                                        "resizable": {
                                          "ratioDefault": 1
                                        },
                                        "attributes": {
                                          "x1": "12",
                                          "y1": "5",
                                          "x2": "12",
                                          "y2": "19"
                                        },
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ]
                                      },
                                      {
                                        "tagName": "line",
                                        "type": "svg-in",
                                        "draggable": false,
                                        "droppable": false,
                                        "highlightable": false,
                                        "resizable": {
                                          "ratioDefault": 1
                                        },
                                        "attributes": {
                                          "x1": "5",
                                          "y1": "12",
                                          "x2": "19",
                                          "y2": "12"
                                        },
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ]
                                      }
                                    ]
                                  }
                                ]
                              },
                              {
                                "tagName": "button",
                                "draggable": false,
                                "droppable": false,
                                "highlightable": false,
                                "selectable": false,
                                "hoverable": false,
                                "classes": [
                                  "action-button",
                                  "add-button-right"
                                ],
                                "attributes": {
                                  "title": "Add template right"
                                },
                                "_undoexc": [
                                  "status",
                                  "open"
                                ],
                                "components": [
                                  {
                                    "type": "svg",
                                    "draggable": false,
                                    "droppable": false,
                                    "highlightable": false,
                                    "resizable": {
                                      "ratioDefault": 1
                                    },
                                    "selectable": false,
                                    "hoverable": false,
                                    "attributes": {
                                      "xmlns": "http://www.w3.org/2000/svg",
                                      "width": "16",
                                      "height": "16",
                                      "viewBox": "0 0 24 24",
                                      "fill": "none",
                                      "stroke": "currentColor",
                                      "stroke-width": "2",
                                      "stroke-linecap": "round",
                                      "stroke-linejoin": "round"
                                    },
                                    "_undoexc": [
                                      "status",
                                      "open"
                                    ],
                                    "components": [
                                      {
                                        "tagName": "line",
                                        "type": "svg-in",
                                        "draggable": false,
                                        "droppable": false,
                                        "highlightable": false,
                                        "resizable": {
                                          "ratioDefault": 1
                                        },
                                        "attributes": {
                                          "x1": "12",
                                          "y1": "5",
                                          "x2": "12",
                                          "y2": "19"
                                        },
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ]
                                      },
                                      {
                                        "tagName": "line",
                                        "type": "svg-in",
                                        "draggable": false,
                                        "droppable": false,
                                        "highlightable": false,
                                        "resizable": {
                                          "ratioDefault": 1
                                        },
                                        "attributes": {
                                          "x1": "5",
                                          "y1": "12",
                                          "x2": "19",
                                          "y2": "12"
                                        },
                                        "_undoexc": [
                                          "status",
                                          "open"
                                        ]
                                      }
                                    ]
                                  }
                                ]
                              },
                              {
                                "type": "text",
                                "draggable": false,
                                "highlightable": false,
                                "editable": false,
                                "selectable": false,
                                "hoverable": false,
                                "classes": [
                                  "resize-handle"
                                ],
                                "_undoexc": [
                                  "status",
                                  "open"
                                ],
                                "components": [
                                  {
                                    "type": "textnode",
                                    "content": "",
                                    "_undoexc": [
                                      "status",
                                      "open"
                                    ]
                                  }
                                ]
                              }
                            ]
                          }
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          }
        }
      ],
      "type": "main",
      "id": "yvNZN2seeDRsRFyl"
    }
  ]
}
`;

class DataManager {
  services = [];
  media = [];
  LocationId = null;
  OrganisationId = null;
  selectedTheme = null;
  constructor(services, media) {
    this.services = services;
    this.media = media;
  }

  getPages() {
    let self = this;
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/pages/list2`,
        type: "GET",
        data: {
          Locationid: self.LocationId,
          Organisationid: self.OrganisationId,
        },
        success: function (response) {
          self.pages = response;
          console.log('getPages', response);
          resolve(self.pages);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  getSinglePage(pageId) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/singlepage?Pageid=${pageId}`,
        type: "GET",
        contentType: "application/json",
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
          reject(error);
        },
      });
    });
  }

  getPagesService() {
    let self = this;
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/pages/list`,
        type: "GET",
        data: {
          Locationid: self.LocationId,
          Organisationid: self.OrganisationId,
        },
        success: function (response) {
          const pages = response;
          console.log('getPageService', pages)
          resolve(pages); // Resolve the promise with the pages
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
          reject(error); // Reject the promise with the error
        },
      });
    });
  }

  updatePage(data) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/update-page`, // Replace with the actual API endpoint
        type: "POST",
        data: JSON.stringify(data),
        success: function (response) {
          resolve(response);
          console.log("Reached update");
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  updateLocationTheme() {
    let themeId = this.selectedTheme.id
    
    console.log("Hello", {
      ThemeId: themeId,
      LocationId :this.LocationId,
      OrganisationId: this.OrganisationId,
    })
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/update-location-theme`, // Replace with the actual API endpoint
        type: "POST",
        data: JSON.stringify({
          ThemeId: themeId,
          LocationId :this.LocationId,
          OrganisationId: this.OrganisationId,
        }),
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  createNewPage(pageName) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/create-page`,
        type: "POST",
        contentType: "application/json", // Ensure JSON content type
        data: JSON.stringify({ PageName: pageName }),
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  addPageChild(childPageId, currentPageId) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/add-page-children`, // Replace with the actual API endpoint
        type: "POST",
        data: JSON.stringify({
          ParentPageId: currentPageId,
          ChildPageId: childPageId,
        }),
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  uploadFile(fileData, fileName, fileSize, fileType) {
    return new Promise((resolve, reject) => {
      if (fileData) {
        $.ajax({
          url: `${baseURL}/api/media/upload`, // Replace with the actual API endpoint
          type: "POST", // POST request as specified in the YAML

          contentType: "multipart/form-data", // Sending JSON as per the request body
          data: JSON.stringify({
            MediaId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            MediaName: fileName,
            MediaImageData: fileData,
            MediaSize: fileSize,
            MediaType: fileType,
          }),
          success: function (response) {
            // Handle a successful response
            resolve(response);
          },
          error: function (xhr, status, error) {
            if (xhr.status === 404) {
              console.error("Error 404: Not Found");
            } else {
              console.error("Error:", status, error);
            }
          },
        });
      } else {
        alert("Please select a file!");
      }
    });
  }

  getMediaFiles() {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/media/`, // Replace with the actual API endpoint
        type: "GET",
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  createContentPage(pageId) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/toolbox/create-content-page`,
        type: "POST",
        contentType: "application/json", // Ensure JSON content type
        data: JSON.stringify({ PageId: pageId }),
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
        },
      });
    });
  }

  getContentPageData(productServiceId) {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/productservice?Productserviceid=${productServiceId}`,
        type: "GET",
        contentType: "application/json",
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
          reject(error);
        },
      });
    });
  }


  getLocationTheme() {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `${baseURL}/api/location-theme?LocationId=${this.LocationId}&OrganisationId=${this.OrganisationId}`,
        type: "GET",
        contentType: "application/json",
        success: function (response) {
          resolve(response);
        },
        error: function (xhr, status, error) {
          if (xhr.status === 404) {
            console.error("Error 404: Not Found");
          } else {
            console.error("Error:", status, error);
          }
          reject(error);
        },
      });
    });
  }
}

const iconsData = [
  {
    name: "Broom",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.86 26.791">
          <path id="Path_942" data-name="Path 942" d="M27.756,3.986a1.217,1.217,0,0,0-1.2,1.234v9.736a2.433,2.433,0,0,0-2.434,2.434v1.217H27.57a1.217,1.217,0,0,0,.4,0h3.459V17.39a2.433,2.433,0,0,0-2.434-2.434V5.22a1.217,1.217,0,0,0-1.236-1.234ZM11.953,4a4.049,4.049,0,0,0-3.6,2.579,3.784,3.784,0,0,0-.663-.145,4.278,4.278,0,0,0-4.26,4.26,4.152,4.152,0,0,0,.062.609H3.434a1.217,1.217,0,1,0,0,2.434H3.6l.825,6.19-3,2.629a1.218,1.218,0,0,0,1.6,1.835l1.79-1.566-.385-2.9,6.729-5.89a1.217,1.217,0,0,1,1.6,1.835L4.808,22.826l.777,5.838A2.437,2.437,0,0,0,8,30.777h7.906a2.434,2.434,0,0,0,2.413-2.113l1.992-14.925h.162a1.217,1.217,0,1,0,0-2.434h-.062a4.152,4.152,0,0,0,.062-.609,4.278,4.278,0,0,0-4.26-4.26,3.784,3.784,0,0,0-.663.145A4.049,4.049,0,0,0,11.953,4Zm0,2.434a1.8,1.8,0,0,1,1.8,1.626,1.217,1.217,0,0,0,1.709.975A1.817,1.817,0,0,1,18.038,10.7a1.858,1.858,0,0,1-.107.609H5.975a1.859,1.859,0,0,1-.107-.609A1.817,1.817,0,0,1,8.445,9.037a1.217,1.217,0,0,0,1.709-.975A1.8,1.8,0,0,1,11.953,6.437Zm12.17,14.6a16.837,16.837,0,0,0-2.434,8.519,1.217,1.217,0,0,0,1.217,1.217h9.736a1.216,1.216,0,0,0,1.21-1.348,16.907,16.907,0,0,0-2.427-8.388h-7.3Z" transform="translate(-1 -3.986)" fill="#7c8791"/>
        </svg>
       `,
  },
  {
    name: "Car",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 33.969 27.499">
          <path id="Path_940" data-name="Path 940" d="M33.625,15.208l-2.689-7.7A5.236,5.236,0,0,0,26,4H11.967A5.233,5.233,0,0,0,7.034,7.507l-2.689,7.7A5.247,5.247,0,0,0,2,19.588V28.88a2.613,2.613,0,1,0,5.226,0V27.228s6.9.342,11.758.342,11.758-.342,11.758-.342V28.88a2.613,2.613,0,1,0,5.226,0V19.588A5.248,5.248,0,0,0,33.625,15.208ZM8,12.659,9.5,8.372a2.614,2.614,0,0,1,2.467-1.753H26a2.614,2.614,0,0,1,2.467,1.753l1.5,4.287a.936.936,0,0,1-1.03,1.24,62.318,62.318,0,0,0-9.952-.733,62.318,62.318,0,0,0-9.952.733A.936.936,0,0,1,8,12.659Zm-.124,9.673a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,7.879,22.332ZM22.9,21.023H15.065a1.309,1.309,0,0,1,0-2.619H22.9a1.309,1.309,0,0,1,0,2.619Zm7.186,1.309a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,30.09,22.332Z" transform="translate(-2 -4)" fill="#7c8791"/>
        </svg>

       `,
  },
  {
    name: "Heart",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 31.83 28.479">
          <path id="Path_941" data-name="Path 941" d="M24.689,3.007a9.543,9.543,0,0,0-6.774,3.3,9.543,9.543,0,0,0-6.774-3.3A8.865,8.865,0,0,0,3.768,6.654C-2.379,14.723,9.259,24.162,12,26.7c1.638,1.516,3.659,3.317,4.865,4.384a1.583,1.583,0,0,0,2.106,0c1.206-1.067,3.228-2.868,4.865-4.384,2.738-2.534,14.377-11.973,8.228-20.041A8.86,8.86,0,0,0,24.689,3.007Z" transform="translate(-2 -3.001)" fill="#7c8791"/>
        </svg>
       `,
  },
  {
    name: "Home",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 28.752 28.752">
          <path id="Path_937" data-name="Path 937" d="M17.376,2a1.2,1.2,0,0,0-.838.342L3.47,13.03l-.044.035-.044.037v0A1.2,1.2,0,0,0,4.2,15.178H5.4V28.356a2.4,2.4,0,0,0,2.4,2.4H26.96a2.4,2.4,0,0,0,2.4-2.4V15.178h1.2a1.2,1.2,0,0,0,.817-2.075l-.019-.014q-.039-.036-.082-.068l-1.914-1.565V6.792a1.2,1.2,0,0,0-1.2-1.2h-1.2a1.2,1.2,0,0,0-1.2,1.2V8.516l-7.574-6.2A1.2,1.2,0,0,0,17.376,2ZM20.97,17.574h4.792v9.584H20.97Z" transform="translate(-3 -2)" fill="#7c8791"/>
        </svg>
       `,
  },
  {
    name: "Health",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 26.214 27.498">
          <path id="Path_938" data-name="Path 938" d="M26.3,4.75H20.208a4.433,4.433,0,0,0-8.2,0H5.913A2.834,2.834,0,0,0,3,7.5V26.748A2.834,2.834,0,0,0,5.913,29.5H26.3a2.834,2.834,0,0,0,2.913-2.75V7.5A2.834,2.834,0,0,0,26.3,4.75Zm-10.194,0a1.418,1.418,0,0,1,1.456,1.375,1.459,1.459,0,0,1-2.913,0A1.418,1.418,0,0,1,16.107,4.75Zm4.369,15.124H17.564v2.75A1.418,1.418,0,0,1,16.107,24h0a1.418,1.418,0,0,1-1.456-1.375v-2.75H11.738A1.418,1.418,0,0,1,10.282,18.5h0a1.418,1.418,0,0,1,1.456-1.375h2.913v-2.75A1.418,1.418,0,0,1,16.107,13h0a1.418,1.418,0,0,1,1.456,1.375v2.75h2.913A1.418,1.418,0,0,1,21.933,18.5h0A1.418,1.418,0,0,1,20.476,19.874Z" transform="translate(-3 -2)" fill="#7c8791"/>
        </svg>
       `,
  },
  {
    name: "Foods",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.813 27.572">
          <path id="Path_939" data-name="Path 939" d="M22.959,3.986a.656.656,0,0,0-.646.665V5.964q0,.019,0,.038A5.905,5.905,0,0,0,17.1,11.214H15.75a.656.656,0,0,0-.656.656v4.594H11.933a7.534,7.534,0,0,0,.445-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,9.9H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,13.183H2.625a.656.656,0,1,0,0,1.313h.091a7.535,7.535,0,0,0,.445,1.969H.656A.656.656,0,0,0,0,17.12v6.563a3.271,3.271,0,0,0,5.906,1.948,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.271,3.271,0,0,0,5.906-1.948V17.12a.656.656,0,0,0-.656-.656H30.844V11.87a.656.656,0,0,0-.656-.656H28.837A5.905,5.905,0,0,0,23.624,6q0-.019,0-.038V4.652a.656.656,0,0,0-.666-.665ZM4.029,7.933h7.037A5.272,5.272,0,0,1,10.473,9.9H4.621A5.272,5.272,0,0,1,4.029,7.933Zm0,3.281h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,11.214Zm12.378,1.313H29.531v3.938H16.406ZM4.029,14.5h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,14.5Zm-1.4,13.729V30.9a.656.656,0,0,0,1.313,0V28.23a4.352,4.352,0,0,1-.656.046A3.64,3.64,0,0,1,2.625,28.224Zm27.562,0a3.64,3.64,0,0,1-.656.053,4.352,4.352,0,0,1-.656-.046V30.9a.656.656,0,0,0,1.313,0Z" transform="translate(0 -3.986)" fill="#7c8791"/>
        </svg>
       `,
  },
  {
    name: "Laundry",
    svg: `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 30.411 28.722">
          <path id="Path_943" data-name="Path 943" d="M13.236,4a2.053,2.053,0,0,0,0,4.1h2.323l-.32.333-.034.033-2.493,2.58a8.153,8.153,0,0,1-1.539-1.907.674.674,0,0,0-1.158,0c-.021.036-1.94,3.543-5.723,3.73l-.98-6.247a.669.669,0,0,0-.638-.584.652.652,0,0,0-.517.238.7.7,0,0,0-.149.564l1.07,6.83s0,.005,0,.008L5.973,32.147s0,.006,0,.009a.7.7,0,0,0,.071.21l.012.02a.679.679,0,0,0,.137.17l.009.007a.657.657,0,0,0,.186.114l.008,0a.641.641,0,0,0,.227.041H27.778A.641.641,0,0,0,28,32.68l.019-.007a.656.656,0,0,0,.186-.114h0l0-.005a.679.679,0,0,0,.136-.168l.009-.017a.7.7,0,0,0,.075-.22l2.9-18.464s0-.005,0-.008l1.07-6.83a.7.7,0,0,0-.222-.662.644.644,0,0,0-.668-.112.681.681,0,0,0-.413.555l-.98,6.252a6.184,6.184,0,0,1-2.519-.672A4.91,4.91,0,0,0,26.423,7.5L24.262,5.265a4.348,4.348,0,0,0-3.184-1.256L13.238,4Zm0,1.368,7.84.009a3.031,3.031,0,0,1,2.251.855l2.161,2.236a3.493,3.493,0,0,1,0,4.832l-6.758,6.9,0,0a.636.636,0,0,1-.935,0,.685.685,0,0,1-.154-.711l2.573-2.662.009-.009q.024-.024.045-.049a.7.7,0,0,0-.016-.908.645.645,0,0,0-.874-.091l-.005.005-.026.021q-.021.018-.041.037l-.008.008-.01.009-.022.023-2.4,2.383-.009.009a2,2,0,0,0-.292.4l-1.508,1.56a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l4.228-4.374a.682.682,0,0,0,.12-.162h0a.7.7,0,0,0-.094-.793.646.646,0,0,0-.756-.16l-.005,0a.659.659,0,0,0-.161.108l-.037.037L13.191,18.29l-.8.825a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l.567-.586,4.185-4.33a.682.682,0,0,0,.12-.163.7.7,0,0,0-.166-.863.644.644,0,0,0-.85.02l-.005.005-.034.033-4.185,4.329a.636.636,0,0,1-.935,0,.688.688,0,0,1,0-.966L16.14,9.436,17.623,7.9a.7.7,0,0,0,.143-.745.661.661,0,0,0-.61-.422H13.236a.684.684,0,0,1,0-1.368Z" transform="translate(-1.998 -4)" fill="#7c8791"/>
        </svg>
       `,
  },
];

const defaultTileAttrs = `
  tile-text="Tile"
  tile-text-color="#000000"
  tile-text-align="left"

  tile-icon="icon-name"
  tile-icon-color="#000000"
  tile-icon-align="left"

  tile-bg-color="#ffffff"

  tile-bg-image=""
  tile-bg-image-opacity=100

  tile-action-object="Page"
  tile-action-object-id=""
`;

const defaultConstraints = `
    data-gjs-draggable="false"
    data-gjs-selectable="false"
    data-gjs-editable="false"
    data-gjs-highlightable="false"
    data-gjs-droppable="false"
    data-gjs-resizable="false"
    data-gjs-hoverable="false"
`;
