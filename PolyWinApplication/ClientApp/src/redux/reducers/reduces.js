import initialState from './initialState';
import persistState from 'redux-localstorage';

export default function (state = initialState, action) {
    switch (action.type) {
        // reducer of Login
        case 'LOGIN':
            const obj = action.data.payload;
            sessionStorage.setItem("UserType", obj.userType);
           sessionStorage.setItem("token", "Bearer " + obj.token);
            sessionStorage.removeItem("role_id");
            sessionStorage.removeItem("name");
            return {    
                ...state,
                token: "Bearer " + obj.token
            };
       // login-employee
        case 'LOGINEMPLOYEE':
            const objEmployee = action.data.payload;
            sessionStorage.removeItem("UserType");
            sessionStorage.removeItem("token");
            sessionStorage.setItem("role_id", objEmployee.roles_id);
            sessionStorage.setItem("name", objEmployee.name);
       
            return {
                ...state,
                rolePermission: objEmployee.roles_id
            };
        case 'LISTACCOUNTS':

            return {
                ...state,
                ListAccounts: action.data.payload
            };
        case 'ACTIVEACCOUNTS':

            let listAcc = state.ListAccounts;

            action.ids.forEach(id => {
                let indexListAcc = listAcc.findIndex(x => x.id === id);
                listAcc.splice(indexListAcc, 1);
            });

            return {
                ...state,
                ListAccounts: [...state.ListAccounts]
            };

        case 'LISTDATASHEETS':

            return {
                ...state,
                ListDataSheets: action.data.payload
            };

        case 'DELETEDATASHEETS':
            let listDataSheets = state.ListDataSheets

            action.ids.map(xx => {
                listDataSheets = listDataSheets.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListDataSheets: [...listDataSheets]
            };

        case 'ADDEDITDATASHEETS':
            let listDataSheet = state.ListDataSheets;

            let indexDataSheet = listDataSheet.findIndex(x => x.id === action.data.payload.id);

            if (indexDataSheet > -1) {
                listDataSheet.splice(indexDataSheet, 1);
            }

            return {
                ...state,
                ListDataSheets: [...state.ListDataSheets, action.data.payload]
            };




        case 'LISTCATALOGUE':

            return {
                ...state,
                ListCatalogue: action.data.payload
            };

        case 'DELETECATALOGUE':
            let listCatalogue = state.ListCatalogue

            action.ids.map(xx => {
                listCatalogue = listCatalogue.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListCatalogue: [...listCatalogue]
            };

        case 'ADDEDITCATALOGUE':
            let listCatalogues = state.ListCatalogue;

            let indexCatalogues = listCatalogues.findIndex(x => x.id === action.data.payload.id);

            if (indexCatalogues > -1) {
                listCatalogues.splice(indexCatalogues, 1);
            }

            return {
                ...state,
                ListCatalogue: [...state.ListCatalogue, action.data.payload]
            };


        case 'LISTFACTOR':

            return {
                ...state,
                ListFactor: action.data.payload
            };

        case 'DELETEFACTOR':
            let listFactor = state.ListFactor

            action.ids.map(xx => {
                listFactor = listFactor.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listFactor: [...listFactor]
            };

        case 'ADDEDITFACTOR':
            let listFactors = state.ListFactor;

            let indexFactors = listFactors.findIndex(x => x.id === action.data.payload.id);

            if (indexFactors > -1) {
                listFactors.splice(indexFactors, 1);
            }

            return {
                ...state,
                ListFactor: [...state.ListFactor, action.data.payload]
            };

        case 'LISTPRICELST':

            return {
                ...state,
                ListPriceLst: action.data.payload
            };

        case 'DELETEPRICELST':
            let listPriceLst = state.ListPriceLst

            action.ids.map(xx => {
                listPriceLst = listPriceLst.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listPriceLst: [...listPriceLst]
            };

        case 'ADDEDITPRICELST':
            let listPriceLsts = state.ListPriceLst;

            let indexPriceLsts = listPriceLsts.findIndex(x => x.id === action.data.payload.id);

            if (indexPriceLsts > -1) {
                listPriceLsts.splice(indexPriceLsts, 1);
            }

            return {
                ...state,
                ListPriceLst: [...state.ListPriceLst, action.data.payload]
            };


        case 'LISTCLIENTCOMM':

            return {
                ...state,
                ListClientComm: action.data.payload
            };

        case 'DELETECLIENTCOMM':
            let listClientComm = state.ListClientComm

            action.ids.map(xx => {
                listClientComm = listClientComm.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listClientComm: [...listClientComm]
            };

        case 'ADDEDITCLIENTCOMM':
            let listClientComms = state.ListClientComm;

            let indexClientComms = listClientComms.findIndex(x => x.id === action.data.payload.id);

            if (indexClientComms > -1) {
                indexClientComms.splice(indexClientComms, 1);
            }

            return {
                ...state,
                ListClientComm: [...state.ListClientComm, action.data.payload]
            };
        case 'COMPANYINFO':

            return {
                ...state,
                objCompanyInfo: action.data
            };

        case 'ADDEDITCOMPANYINFO':

            return {
                ...state,
                objCompanyInfo: action.data
            };

        case 'GETALLCATEGORYTYPE':
            return {
                ...state,
                ListCategoryType: action.data
            };

        case 'DELETECATEGORYTYPE':
            let listCategoryType = state.ListCategoryType

            action.ids.map(xx => {
                listCategoryType = listCategoryType.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListCategoryType: [...listCategoryType]
            };

        case 'ADDEDITCATEGORYTYPE':
            let _listCategoryType = state.ListCategoryType;

            let indexCategoryType = _listCategoryType.findIndex(x => x.id === action.data.payload.id);

            if (indexCategoryType > -1) {
                _listCategoryType.splice(indexCategoryType, 1);
            }

            return {
                ...state,
                ListCategoryType: [...state.ListCategoryType, action.data.payload]
            };

        case 'GETALLCATEGORYTYPEFORDROP':
            let objCategoryType = [];

            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.name
                }
                objCategoryType.push(objDept);
            });

            return {
                ...state,
                listCategoryForDrop: objCategoryType
            };

        case 'GETALLCATEGORYGALLERY':
            return {
                ...state,
                ListCategoryGallery: action.data
            };

        case 'ADDEDITCATEGORYGALLERY':
            let _listCategoryGallery = state.ListCategoryGallery;

            let indexCategoryGallery = _listCategoryGallery.findIndex(x => x.id === action.data.id);

            if (indexCategoryGallery > -1) {
                _listCategoryGallery.splice(indexCategoryGallery, 1);
            }

            return {
                ...state,
                ListCategoryGallery: [...state.ListCategoryGallery, action.data]
            };

        case 'DELETECATEGORYGALLERY':
            let listCategoryGallery = state.ListCategoryGallery

            action.ids.map(xx => {
                listCategoryGallery = listCategoryGallery.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListCategoryGallery: [...listCategoryGallery]
            };




        case 'GETALLCATEGORYGALLERYFORDROP':
            let objCategoryGallery = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.categoryName
                }

                objCategoryGallery.push(objDept);
            });

            return {
                ...state,
                listCategoryGalleryForDrop: objCategoryGallery
            };

        case 'GETALLCATEGORYCHILDGALLERY':
            return {
                ...state,
                ListCategoryChildGallery: action.data
            };

        case 'ADDEDITCATEGORYCHILDGALLERY':
            let _listCategoryChildGallery = state.ListCategoryChildGallery;

            let indexCategoryChildGallery = _listCategoryChildGallery.findIndex(x => x.id === action.data.id);

            if (indexCategoryChildGallery > -1) {
                _listCategoryChildGallery.splice(indexCategoryChildGallery, 1);
            }

            return {
                ...state,
                ListCategoryChildGallery: [...state.ListCategoryChildGallery, action.data]
            };

        case 'DELETECATEGORYCHILDGALLERY':
            let listCategoryChildGallery = state.ListCategoryChildGallery

            action.ids.map(xx => {
                listCategoryChildGallery = listCategoryChildGallery.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListCategoryChildGallery: [...listCategoryChildGallery]
            };



        case 'GETALLCATEGORYCHILDGALLERYFORDROP':
            let objCategoryChildGallery = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.categoryChildName
                }

                objCategoryChildGallery.push(objDept);
            });

            return {
                ...state,
                listCategoryChildGalleryForDrop: objCategoryChildGallery
            };

        case 'GALLERYType':
            return {
                ...state,
                listGallery: action.data
            };

        case 'ADDEDITGALLERY':
            let _listGallery = state.listGallery;

            let indexGallery = _listGallery.findIndex(x => x.id === action.data.id);

            if (indexGallery > -1) {
                _listGallery.splice(indexGallery, 1);
            }

            return {
                ...state,
                listGallery: [...state.listGallery, action.data]
            };

        case 'DELETEGALLERY':
            let listGallery = state.listGallery

            action.ids.map(xx => {
                listGallery = listGallery.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listGallery: [...listGallery]
            };


        case 'GETALLCOLORS':
            return {
                ...state,
                ListColors: action.data
            };

        case 'ADDEDITCOLORS':
            let _ListColors = state.ListColors;

            let indexColors = _ListColors.findIndex(x => x.id === action.data.id);

            if (indexColors > -1) {
                _ListColors.splice(indexColors, 1);
            }

            return {
                ...state,
                ListColors: [...state.ListColors, action.data]
            };

        case 'DELETECOLORS':
            let listColors = state.ListColors

            action.ids.map(xx => {
                listColors = listColors.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListColors: [...listColors]
            };



        case 'GETALLPARENTCATEGORY':
            return {
                ...state,
                ListParentCategory: action.data
            };

        case 'ADDEDITPARENTCATEGORY':
            let _ListParentCategory = state.ListParentCategory;

            let indexParentCategory = _ListParentCategory.findIndex(x => x.id === action.data.id);

            if (indexParentCategory > -1) {
                _ListParentCategory.splice(indexParentCategory, 1);
            }

            return {
                ...state,
                ListParentCategory: [...state.ListParentCategory, action.data]
            };

        case 'DELETEPARENTCATEGORY':
            let listParentCategory = state.ListParentCategory

            action.ids.map(xx => {
                listParentCategory = listParentCategory.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListParentCategory: [...listParentCategory]
            };


        case 'GETALLPRODUCTNAME':
            return {
                ...state,
                ListProductName: action.data
            };

        case 'ADDEDITPRODUCTNAME':
            let _ListProductName = state.ListProductName;

            let indexProductName = _ListProductName.findIndex(x => x.id === action.data.id);

            if (indexProductName > -1) {
                _ListProductName.splice(indexProductName, 1);
            }

            return {
                ...state,
                ListProductName: [...state.ListProductName, action.data]
            };

        case 'DELETEPRODUCTNAME':
            let listProductName = state.ListProductName

            action.ids.map(xx => {
                listProductName = listProductName.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListProductName: [...listProductName]
            };


        case 'GETALLPARENTPRODUCTCATEGORY':
            return {
                ...state,
                ListParentProductCategory: action.data
            };

        case 'ADDEDITPARENTPRODUCTCATEGORY':
            let _ListParentProductCategory = state.ListParentProductCategory;

            let indexParentProductCategory = _ListParentProductCategory.findIndex(x => x.id === action.data.id);

            if (indexParentProductCategory > -1) {
                _ListParentProductCategory.splice(indexParentProductCategory, 1);
            }

            return {
                ...state,
                ListParentProductCategory: [...state.ListParentProductCategory, action.data]
            };

        case 'DELETEPARENTPRODUCTCATEGORY':
            let listParentProductCategory = state.ListParentProductCategory

            action.ids.map(xx => {
                listParentProductCategory = listParentProductCategory.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListParentProductCategory: [...listParentProductCategory]
            };


        case 'GETALLPARENTPRODUCTCATEGORYFORDROP':
            let objCategory = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.catgoryName
                }

                objCategory.push(objDept);
            });

            return {
                ...state,
                ListParentProductCategoryForDrop: objCategory
            };


        case 'GETALLCATEGORY':
            return {
                ...state,
                listCategory: action.data
            };

        case 'ADDEDITCATEGORY':
            let _listCategory = state.listCategory;

            let indexCategory = _listCategory.findIndex(x => x.id === action.data.id);

            if (indexCategory > -1) {
                _listCategory.splice(indexCategory, 1);
            }

            return {
                ...state,
                listCategory: [...state.listCategory, action.data]
            };

        case 'DELETECATEGORY':
            let ListCategory = state.listCategory

            action.ids.map(xx => {
                ListCategory = ListCategory.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listCategory: [...ListCategory]
            };


        case 'PRODUCTFORDROP':
            let objProductName = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.productName
                }

                objProductName.push(objDept);
            });

            return {
                ...state,
                ListProductNameForDrop: objProductName
            };

        case 'COLORSFORDROP':
            let objProductColor = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.colorName
                }

                objProductColor.push(objDept);
            });

            return {
                ...state,
                ListProductColorForDrop: objProductColor
            };

        case 'CATEGORYFORDROP':
            let objProductCategory = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.categoryName
                }

                objProductCategory.push(objDept);
            });

            return {
                ...state,
                ListProductCategoryForDrop: objProductCategory
            };

        case 'GETALLPRODUCT':
            return {
                ...state,
                listProducts: action.data
            };

        case 'ADDEDITPRODUCT':
            let _listProducts = state.listProducts;

            let indexProducts = _listProducts.findIndex(x => x.id === action.data.id);

            if (indexProducts > -1) {
                _listProducts.splice(indexProducts, 1);
            }

            return {
                ...state,
                listProducts: [...state.listProducts, action.data]
            };

        case 'DELETEPRODUCT':
            let ListProducts = state.listProducts

            action.ids.map(xx => {
                ListProducts = ListProducts.filter(x => x.id !== xx);
            });

            return {
                ...state,
                listProducts: [...ListProducts]
            };

        case 'PARENTCATEGORY':
            let objParentCategory = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.name
                }

                objParentCategory.push(objDept);
            });

            return {
                ...state,
                ListParentCategoryForDrop: objParentCategory
            };


        case 'GETALLSUBCATEGORY':
            return {
                ...state,
                ListSubCategory: action.data
            };

        case 'ADDEDITSUBCATEGORY':
            let _listSubCategory = state.ListSubCategory;

            let indexSubCategory = _listSubCategory.findIndex(x => x.id === action.data.id);

            if (indexSubCategory > -1) {
                _listSubCategory.splice(indexSubCategory, 1);
            }

            return {
                ...state,
                ListSubCategory: [...state.ListSubCategory, action.data]
            };

        case 'DELETESUBCATEGORY':
            let listSubCategory = state.ListSubCategory

            action.ids.map(xx => {
                listSubCategory = listSubCategory.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListSubCategory: [...listSubCategory]
            };


        case 'GETSUBCATEGORYFORDROP':
            let objSubCategory = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.name
                }

                objSubCategory.push(objDept);
            });

            return {
                ...state,
                ListSubCategoryForDrop: objSubCategory
            };

        case 'GETPRODUCTFORDROP':
            let objProduct = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.productName
                }

                objProduct.push(objDept);
            });

            return {
                ...state,
                ListProductForDrop: objProduct
            };



        case 'ADDEDITPRODUCTING':
            let _listProductIngredient = state.ListProductIngredient;

            let indexProductIngredient = _listProductIngredient.findIndex(x => x.id === action.data.id);

            if (indexProductIngredient > -1) {
                _listProductIngredient.splice(indexProductIngredient, 1);
            }

            return {
                ...state,
                ListProductIngredient: [...state.ListProductIngredient, action.data]
            };

        case 'DELETEPRODUCTING':
            let listProductIngredient = state.ListProductIngredient

            action.ids.map(xx => {
                listProductIngredient = listProductIngredient.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListProductIngredient: [...listProductIngredient]
            };

        case 'GETALLPRODUCTING':
            return {
                ...state,
                ListProductIngredient: action.data
            };

        case 'LISTACCOUNTSACTIVENOTACTIVE':
            return {
                ...state,
                ListAccountsActiveNotActive: action.data
            };

        case 'GETPARENTPRODUCTFORDROP':
            let _objParentCategory = [];
            action.data.forEach(item => {
                let objDept = {
                    value: item.id,
                    label: item.catgoryName
                }

                _objParentCategory.push(objDept);
            });

            return {
                ...state,
                ListParentCategoryForDrop: _objParentCategory
            };



        case 'ADDEDITDESCOUNT':
            let _listDescount = state.ListDescount;

            let indexDescount = _listDescount.findIndex(x => x.id === action.data.id);

            if (indexDescount > -1) {
                _listDescount.splice(indexDescount, 1);
            }

            return {
                ...state,
                ListDescount: [...state.ListDescount, action.data]
            };

        case 'DELETEDESCOUNT':
            let listDescount = state.ListDescount

            action.ids.map(xx => {
                listDescount = listDescount.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListDescount: [...listDescount]
            };

        case 'GETALLDESCOUNT':
            return {
                ...state,
                ListDescount: action.data
            };




        case 'ADDEDITINGREACCESS':
            let _listProductIngredientAccess = state.ListProductIngredientAccess;

            let indexProductIngredientAccess = _listProductIngredientAccess.findIndex(x => x.id === action.data.id);

            if (indexProductIngredientAccess > -1) {
                _listProductIngredientAccess.splice(indexProductIngredientAccess, 1);
            }

            return {
                ...state,
                ListProductIngredientAccess: [...state.ListProductIngredientAccess, action.data]
            };

        case 'DELETEINGREACCESS':
            let listProductIngredientAccess = state.ListProductIngredientAccess

            action.ids.map(xx => {
                listProductIngredientAccess = listProductIngredientAccess.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListProductIngredientAccess: [...listProductIngredientAccess]
            };

        case 'GETALLINGREACCESS':
            return {
                ...state,
                ListProductIngredientAccess: action.data
            };

        case 'RESETPASSWORD':
            return {
                ...state
            };

        default:
            return {
                ...state
            };
        //MESSAGES
        case 'LISTMESSAGES':
            return {
                ...state,
                ListMessage: action.data.payload
            };

        //supplier
        case 'LISTSUPPLIER':

            return {
                ...state,
                ListSupplier: action.data.payload
            };
        case 'COUNTSUPPLIER':

            return {
                ...state,
                CountSupplier: action.data
            };
        case 'DELETESUPPLIER':
            let ListSupplier = state.ListSupplier

            action.ids.map(xx => {
                ListSupplier = ListSupplier.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListSupplier: [...ListSupplier]
            };

        case 'ADDEDITSUPPLIER':
            let ListSuppliers = state.ListSupplier;

            let indexSuppliers = ListSuppliers.findIndex(x => x.id === action.data.payload.id);

            if (indexSuppliers > -1) {
                ListSuppliers.splice(indexSuppliers, 1);
            }

            return {
                ...state,
                ListSupplier: [...state.ListSupplier, action.data.payload]
            };
        case 'LISTSUPPLIERFORDROP':
            let objSuppliers = [];
            action.data.forEach(item => {
                let objSupplier = {
                    value: item.id,
                    label: item.name
                }

                objSuppliers.push(objSupplier);
            });

            return {
                ...state,
                ListSupplierForDrop: objSuppliers
            };
        //agent
        case 'LISTAGENT':
            return {
                ...state,
                ListAgent: action.data.payload
            };

        case 'DELETEAGENT':
            let ListAgent = state.ListAgent

            action.ids.map(xx => {
                ListAgent = ListAgent.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListAgent: [...ListAgent]
            };
        //store
        case 'LISTSTORE':

            return {
                ...state,
                ListStore: action.data.payload
            };

        case 'DELETESTORE':
            let ListStore = state.ListStore

            action.ids.map(xx => {
                ListStore = ListStore.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListStore: [...ListStore]
            };

        case 'ADDEDITSTORE':
            let ListStores = state.ListStore;

            let indexStores = ListStores.findIndex(x => x.id === action.data.payload.id);

            if (indexStores > -1) {
                ListStores.splice(ListStores, 1);
            }

            return {
                ...state,
                ListStore: [...state.ListStore, action.data.payload]
            };
        case 'LISTSTOREFORDROP':
            let objStores = [];
            action.data.forEach(item => {
                let objStore = {
                    value: item.id,
                    label: item.storeName
                }

                objStores.push(objStore);
            });

            return {
                ...state,
                ListStoreForDrop: objStores
            };

        //bank
        case 'LISTBANKOut':

            return {
                ...state,
                ListBankOut: action.data.payload
            };
        //bank outside
        case 'LISTBANKOutDROP':
            let objBankOuts = [];
            action.data.forEach(item => {
                let objBankOut = {
                    value: item.id,
                    label: item.nameBank
                }

                objBankOuts.push(objBankOut);
            });

            return {
                ...state,
                ListBankOutForDrop: objBankOuts
            };
            
        case 'DELETEBANKOut':
            let ListBankOut = state.ListBankOut

            action.ids.map(xx => {
                ListBankOut = ListBankOut.filter(x => x.id !== xx);
            });
            return {
                ...state,
                ListBankOut: [...ListBankOut]
            };

        case 'ADDEDITBANKOut':
            let ListBankOuts = state.ListBankOut;

            let indexBankOuts = ListBankOuts.findIndex(x => x.id === action.data.payload.id);

            if (indexBankOuts > -1) {
                ListBankOuts.splice(ListBankOuts, 1);
            }

            return {
                ...state,
                ListBankOut: [...state.ListBankOut, action.data.payload]
            };
            case 'LISTBANKOut':

                return {
                    ...state,
                    ListBankOut: action.data.payload
                };
            //EMPLOYEES
            case 'LISTEMPLOYEE':               
                return {
                    ...state,
                    ListEmployee: action.data.payload
                };
    
            case 'DELETEEMPLOYEE':
                let ListEmployee = state.ListEmployee
    
                action.ids.map(xx => {
                    ListEmployee = ListEmployee.filter(x => x.id !== xx);
                });
                return {
                    ...state,
                    ListEmployee: [...ListEmployee]
                };
    
            case 'ADDEDITEMPLOYEE':
                let ListEmployees = state.ListEmployee;
    
                let indexemps = ListEmployees.findIndex(x => x.id === action.data.payload.id);
    
                if (indexemps > -1) {
                    ListEmployees.splice(ListEmployees, 1);
                }
    
                return {
                    ...state,
                    ListEmployee: [...state.ListEmployee, action.data.payload]
                };
                //roles
                case 'LISTROLEDD':
                    let objRoles = [];
                    action.data.forEach(item => {
                        let objRole = {
                            value: item.id,
                            label: item.name
                        }
        
                        objRoles.push(objRole);
                    });
        
                    return {
                        ...state,
                        ListRoleDD: objRoles
                    };
        //itemtype
        case 'LISTITEMTYPE':

            return {
                ...state,
                ListItemType: action.data.payload
            };

        case 'DELETEITEMTYPE':
            let ListItemType = state.ListItemType

            action.ids.map(xx => {
                ListItemType = ListItemType.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListItemType: [...ListItemType]
            };

        case 'ADDEDITITEMTYPE':
            let ListItemTypes = state.ListItemType;

            let indexItemTypes = ListItemTypes.findIndex(x => x.id === action.data.payload.id);

            if (indexItemTypes > -1) {
                ListItemTypes.splice(indexItemTypes, 1);
            }

            return {
                ...state,
                ListItemType: [...state.ListItemType, action.data.payload]
            };
        case 'LISTITEMTYPEFORDROP':
            let objItemTypes = [];
            action.data.forEach(item => {
                let objItemType = {
                    value: item.id,
                    label: item.nameItemType
                }

                objItemTypes.push(objItemType);
            });

            return {
                ...state,
                ListItemTypeForDrop: objItemTypes
            };

        //bank
        case 'LISTBANK':

            return {
                ...state,
                ListBank: action.data.payload
            };

        case 'DELETEBANK':
            let ListBank = state.ListBank

            action.ids.map(xx => {
                ListBank = ListBank.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListBank: [...ListBank]
            };

        case 'ADDEDITBANK':
            let ListBanks = state.ListBank;

            let indexListBanks = ListBanks.findIndex(x => x.id === action.data.payload.id);

            if (indexListBanks > -1) {
                ListBanks.splice(indexListBanks, 1);
            }

            return {
                ...state,
                ListBank: [...state.ListBank, action.data.payload]
            };
        case 'LISTBANKDROP':
            let objBanks = [];
            action.data.forEach(item => {
                let objBank = {
                    value: item.id,
                    label: item.nameBank
                }
                objBanks.push(objBank);
            });

            return {
                ...state,
                ListBankForDrop: objBanks
            };
        //payment
        case 'LISTPAYMENTFORDROP':
            let objPayments = [];
            action.data.forEach(item => {
                let objPayment = {
                    value: item.id,
                    label: item.namePaymentMethod
                }
                objPayments.push(objPayment);
            });

            return {
                ...state,
                ListPaymentForDrop: objPayments
            };
        //Currency
        case 'LISTCURRENCY':

            return {
                ...state,
                ListCurrency: action.data.payload
            };

        case 'DELETEITCURRENCY':
            let ListCurrency = state.ListCurrency

            action.ids.map(xx => {
                ListCurrency = ListCurrency.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListCurrency: [...ListCurrency]
            };

        case 'ADDEDITCURRENCY':
            let ListCurrencys = state.ListCurrency;

            let indexCurrencys = ListCurrencys.findIndex(x => x.id === action.data.payload.id);

            if (indexCurrencys > -1) {
                ListCurrencys.splice(ListCurrencys, 1);
            }

            return {
                ...state,
                ListCurrency: [...state.ListCurrency, action.data.payload]
            };
        case 'LISTCURRENCYFORDROP':
            let objCurrencys = [];
            action.data.forEach(item => {
                let objCurrency = {
                    value: item.id,
                    label: item.nameCurrency
                }

                objCurrencys.push(objCurrency);
            });

            return {
                ...state,
                ListCurrencyForDrop: objCurrencys
            };
        //purchase
        case 'LISTPURCHASE':

            return {
                ...state,
                ListPurchase: action.data.payload
            };

        case 'DELETEPURCHASE':
            let ListPurchase = state.ListPurchase

            action.ids.map(xx => {
                ListPurchase = ListPurchase.filter(x => x.id !== xx);
            });

            return {
                ...state,
                ListPurchase: [...ListPurchase]
            };

        case 'ADDEDITPURCHASE':
            let ListPurchases = state.ListPurchase;

            let indexPurchasess = ListPurchases.findIndex(x => x.id === action.data.payload.id);

            if (indexPurchasess > -1) {
                ListPurchases.splice(indexPurchasess, 1);
            }

            return {
                ...state,
                ListPurchase: [...state.ListPurchase, action.data.payload]
            };
        // ?????
        case 'ADDDEPOSIT':
            let ListBankOutDeposite = state.ListBankOut;

            let indexBankOut = ListBankOutDeposite.findIndex(x => x.id === action.data.payload.id);

            if (indexBankOut > -1) {
                ListBankOutDeposite.splice(indexBankOut, 1);
            }

            return {
                ...state,
                ListBankOutDeposite: [...state.ListBankOut, action.data.payload]
            };
        // ???
        case 'DECDEPOSIT':
            let ListBankOutDepositedec = state.ListBankOut;

            let indexBankOutdec = ListBankOutDepositedec.findIndex(x => x.id === action.data.payload.id);

            if (indexBankOutdec > -1) {
                ListBankOutDepositedec.splice(indexBankOut, 1);
            }

            return {
                ...state,
                ListBankOutDepositedec: [...state.ListBankOut, action.data.payload]
            };
    }
}