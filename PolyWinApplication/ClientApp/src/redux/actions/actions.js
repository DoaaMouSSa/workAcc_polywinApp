import * as types from './types';
import axiosDocsControlle from '../../axios/axiosControlle';
import axiosLogin from '../../axios/axiosLogin';
import toastr from 'toastr';
import defaultURLDataSheet from '../../axios/axiosControllerDataSheets';
import defaultURLSupplier from '../../axios/axiosControllerSupplier';
import defaultURLPurchase from '../../axios/axiosControllerPurchase';
import defaultURLItemType from '../../axios/axiosContollerItemType';
import defaultURLStore from '../../axios/axiosControllerStore';
import defaultURLMessage from '../../axios/axiosMessageController';
import defaultURLCurrency from '../../axios/axiosControllerCurrency';
import defaultURLBank from '../../axios/axiosControllerBank';
import defaultURLProductName from '../../axios/axiosContollerProductName';
import defaultURLAgent from '../../axios/axiosControllerAgent';
import defaultURLCompanyInfo from '../../axios/axiosControllerCompInfo';
import defaultURLDiscount from '../../axios/axiosControllerDiscount';
import defaultURLParentProductCategory from '../../axios/axiosControllerdefaultURLParentProductCategory';
import defaultURLCategoryType from '../../axios/axiosCategoryType';
import defaultURLCategoryGallery from '../../axios/axiosCategoryGallery';
import defaultURLCategoryChildGallery from '../../axios/axiosControllerCategoryChildGallery';
import defaultURLGallery from '../../axios/axiosControllerGallery';
import defaultURLColors from '../../axios/axiosControllerColor';
import defaultURLProduct from '../../axios/axiosControllerProduct';
import defaultURLCategoryCost  from '../../axios/axiosControllerCatCost';
import defaultURLProductIngredients from '../../axios/axiosProductIngredients';
import defaultURLProIngredientsAccessory from '../../axios/axiosControllerProductIngredientAccessory';
import defaultURLCatalog from '../../axios/axiosControllerCatalog';
import defaultURLFactor from '../../axios/axiosControllerFactor';
import defaultURLClientComments from '../../axios/axiosClientComments';
import defaultURLCategory from '../../axios/axiosCategory';
import defaultURLBankOut from '../../axios/axiosBank';
import defaultURLPayments from '../../axios/axiosPayment';
import defaultURLEmployee from '../../axios/axiosEmployee';
import defaultURLRole from '../../axios/axiosRole';
import defaultURLPurchaseInvoice from '../../axios/axiosPurchaseInvoice';

export function login(userInfo) {
    return (dispatch) => {
        axiosLogin.post(`Login`, userInfo).then(function (response) {
            if (response.status === 200) {
                toastr.success("تم تسجيل الدخول بنجاح");
                dispatch({
                    type: types.LOGIN,
                    data: response.data
                });
            } else {
                toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
            }
        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}
export function loginForEmployees(user) {
    return (dispatch) => {
        defaultURLEmployee.post(`LoginEmployee`, user).then(function (response) {
            if (response.status === 200) {
                toastr.success("تم تسجيل الدخول بنجاح");
                dispatch({
                    type: types.LOGINEMPLOYEE,
                    data: response.data
                });
            } else {
                toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
            }
        }).catch(function (error) {
            console.log("LoginEmployee: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}

export function getAllAccounts(userInfo) {
    return (dispatch) => {
        axiosDocsControlle.get(`GetUserNotActive`).then(function (response) {

            dispatch({
                type: types.LISTACCOUNTS,
                data: response.data
            });

        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}



export function getAllAccountsActiveNotActive(userInfo) {
    return (dispatch) => {
        axiosDocsControlle.get(`GetAllAccounts`).then(function (response) {

            dispatch({
                type: types.LISTACCOUNTSACTIVENOTACTIVE,
                data: response.data
            });

        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}

export function activeAccounts(ids) {
    return (dispatch) => {
        axiosDocsControlle.get(`activeAccounts?ids=${ids.toString()}`).then(function (response) {

            toastr.success("تم تفعيل الحسابات بنجاح");

            dispatch({
                type: types.ACTIVEACCOUNTS,
                ids
            });
        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}



export function activeNotActiveAccounts(ids) {
    return (dispatch) => {
        axiosDocsControlle.get(`ActiveNotActiveAccounts?ids=${ids.toString()}`).then(function (response) {
            toastr.success("تم تعديل الحسابات بنجاح");
            axiosDocsControlle.get(`GetAllAccounts`).then(function (res) {
                dispatch({
                    type: types.LISTACCOUNTSACTIVENOTACTIVE,
                    data: res.data
                });
            });
        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}


export function resetPassword(ids) {
    return (dispatch) => {
        axiosDocsControlle.get(`ResetPassword?ids=${ids.toString()}`).then(function (response) {

            toastr.success("تم تعيين كلمة المرور بنجاح");

            dispatch({
                type: types.RESETPASSWORD,
                ids
            });
        }).catch(function (error) {
            console.log("login: ", error);
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
        });
    };
}

export function getAllDataSheets() {
    return (dispatch) => {
        defaultURLDataSheet.get(`GetAllDataSheet`).then(function (response) {
            dispatch({
                type: types.LISTDATASHEETS,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getAllDataSheets: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditDataSheets(obj) {
    return (dispatch) => {
        defaultURLDataSheet.post(`AddEditDataSheets`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");

            dispatch({
                type: types.ADDEDITDATASHEETS,
                data: response.data
            });
        }).catch(function (error) {
            console.log("addeditDataSheets: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteDataSheet(ids) {
    return (dispatch) => {
        defaultURLDataSheet.get(`DeleteDataSheets?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");

                dispatch({
                    type: types.DELETEDATASHEETS,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("getAllDataSheets: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}






export function getAllCatalogue() {
    return (dispatch) => {
        defaultURLCatalog.get(`GetAllCatalogue`).then(function (response) {
            dispatch({
                type: types.LISTCATALOGUE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getAllCatalogue: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function addeditCatalogue(obj) {
    return (dispatch) => {
        defaultURLCatalog.post(`AddEditCatalogue`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCATALOGUE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("addeditCatalogue: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteCatalogue(ids) {
    return (dispatch) => {
        defaultURLCatalog.get(`DeleteCatalogue?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETECATALOGUE,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("deleteCatalogue: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//supplier
export function getAllSupplier() {
    return (dispatch) => {
        defaultURLSupplier.get(`getAllSupplier`).then(function (response) {
            dispatch({
                type: types.LISTSUPPLIER,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getAllSupplier: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getCountSup() {
    return (dispatch) => {
        defaultURLSupplier.get(`GetSupplierCount`).then(function (response) {
            dispatch({
                type: types.COUNTSUPPLIER,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetSupplierCount: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getAllSupplierForDrop() {
    return (dispatch) => {
        defaultURLSupplier.get(`getAllSupplierForDropDown`).then(function (response) {
            dispatch({
                type: types.LISTSUPPLIERFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllSupplierForDropDown: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditSupplier(obj) {
    return (dispatch) => {
        defaultURLSupplier.post(`AddEditSupplier`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITSUPPLIER,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditSupplier: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteSupplier(ids) {
    return (dispatch) => {
        defaultURLSupplier.get(`deleteSupplier?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETESUPPLIER,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("deleteSupplier: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

//agent
export function getAllAgent() {
    return (dispatch) => {
        defaultURLAgent.get(`GetAllAgents`).then(function (response) {
            dispatch({
                type: types.LISTAGENT,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllUserTypeAgentDetails: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function addeditAgent(obj) {
    return (dispatch) => {
        defaultURLAgent.post(`UpdateAgentInfo`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITAGENT,
                data: response.data
            });
        }).catch(function (error) {
            console.log("UpdateAgentInfo: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function deleteAgent(ids) {
    return (dispatch) => {
        defaultURLAgent.get(`DeleteAgent?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEAGENT,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteAgent: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//Bank
export function getAllBank() {
    return (dispatch) => {
        defaultURLBank.get(`getBanque`).then(function (response) {
            dispatch({
                type: types.LISTBANK,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getBanque: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function getBankForDropDown() {
    return (dispatch) => {
        defaultURLBank.get(`getBanqueForDropDown`).then(function (response) {
            dispatch({
                type: types.LISTBANKDROPDOWN,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getBanqueForDropDown: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function AddEditBank(obj) {
    return (dispatch) => {
        defaultURLBank.post(`AddEditBanque`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITBANK,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditBanque: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function DeleteBank(ids) {
    return (dispatch) => {
        defaultURLBank.get(`DeleteBanque?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEBANK,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteBanque: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//store
export function getAllStore() {
    return (dispatch) => {
        defaultURLStore.get(`getAllStore`).then(function (response) {
            dispatch({
                type: types.LISTSTORE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getAllStore: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getAllStoreForDrop() {
    return (dispatch) => {
        defaultURLStore.get(`getAllStoreForDropDown`).then(function (response) {
            dispatch({
                type: types.LISTSTOREFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllStoreForDropDown: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function DeleteStore(ids) {
    return (dispatch) => {
        defaultURLStore.get(`DeleteStore?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETESTORE,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteStore: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//messages
export function getAllMessages() {
    return (dispatch) => {
        defaultURLMessage.get(`GetAllMessages`).then(function (response) {
            dispatch({
                type: types.LISTMESSAGES,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllMessages: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//roles
export function getAllRolesDD() {
    return (dispatch) => {
        defaultURLRole.get(`GetAllRole`).then(function (response) {
            dispatch({
                type: types.LISTROLEDD,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllRole: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//ItemType
export function getAllItemType() {
    return (dispatch) => {
        defaultURLItemType.get(`getAllItemType`).then(function (response) {
            dispatch({
                type: types.LISTITEMTYPE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getAllItemType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getAllItemTypeForDrop() {
    return (dispatch) => {
        defaultURLItemType.get(`getAllItemType`).then(function (response) {
            dispatch({
                type: types.LISTITEMTYPEFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllItemType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function AddEditItemType(obj) {
    return (dispatch) => {
        defaultURLItemType.post(`AddEditItemType`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITITEMTYPE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditItemType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function DeleteItemType(ids) {
    return (dispatch) => {
        defaultURLItemType.get(`DeleteItemType?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEITEMTYPE,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteItemType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//employess
export function GetEmployee() {
    return (dispatch) => {
        defaultURLEmployee.get(`GetAllEmployee`).then(function (response) {
            dispatch({
                type: types.LISTEMPLOYEE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllEmployee: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addEditEmployee(obj) {
    return (dispatch) => {
        defaultURLEmployee.post(`AddEditEmployee`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITEMPLOYEE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditEmployee: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function deleteEmployee(ids) {
    return (dispatch) => {
        defaultURLEmployee.get(`DeleteEmployee?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEEMPLOYEE,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteEmployee: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//Banks
export function getBankOuts() {
    return (dispatch) => {
        defaultURLBankOut.get(`getBank`).then(function (response) {
            dispatch({
                type: types.LISTBANKOut,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getBank: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getBankOutForDrop() {
    return (dispatch) => {
        defaultURLBankOut.get(`getBank`).then(function (response) {
            dispatch({
                type: types.LISTBANKOutDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getBank: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function AddEditBankOut(obj) {
    return (dispatch) => {
        defaultURLBankOut.post(`AddEditBank`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITBANKOut,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditBank: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function addDeposit(obj) {
    return (dispatch) => {
        defaultURLBank.post(`AddDeposit`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDDEPOSIT,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddDeposit: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function decreasedeposit(obj) {
    return (dispatch) => {
        defaultURLBank.post(`DecreaseDeposit`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.DECDEPOSIT,
                data: response.data
            });
        }).catch(function (error) {
            console.log("DecreaseDeposit: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function DeleteBankOut(ids) {
    return (dispatch) => {
        defaultURLBankOut.get(`DeleteBank?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEBANKOut,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteBank: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//payment
export function getPaymentForDrop() {
    return (dispatch) => {
        defaultURLPayments.get(`getPayment`).then(function (response) {
            dispatch({
                type: types.LISTPAYMENTFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getPayment: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//Currency
export function getCurrency() {
    return (dispatch) => {
        defaultURLCurrency.get(`getCurrency`).then(function (response) {
            dispatch({
                type: types.LISTCURRENCY,
                data: response.data
            });
        }).catch(function (error) {
            console.log("getCurrency: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function getCurrencyForDrop() {
    return (dispatch) => {
        defaultURLCurrency.get(`getCurrency`).then(function (response) {
            dispatch({
                type: types.LISTCURRENCYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getCurrency: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function AddEditCurrency(obj) {
    return (dispatch) => {
        defaultURLCurrency.post(`AddEditCurrency`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCURRENCY,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditCurrency: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function DeleteCurrency(ids) {
    return (dispatch) => {
        defaultURLCurrency.get(`DeleteCurrency?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEITCURRENCY,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteCurrency: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
//Purchase
export function getPurchase() {
    return (dispatch) => {
        defaultURLPurchaseInvoice.get(`GetAllPurchaseInvoices`).then(function (response) {
            dispatch({
                type: types.LISTPURCHASE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllPurchaseInvoices: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function AddEditPurchase(obj) {
    return (dispatch) => {
        defaultURLPurchase.post(`AddEditPurchase`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPURCHASE,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditPurchase: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function DeletePurchase(ids) {
    return (dispatch) => {
        defaultURLPurchase.get(`DeletePurchase?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");
                dispatch({
                    type: types.DELETEPURCHASE,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeletePurchase: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function GetAllFactor() {
    return (dispatch) => {
        defaultURLFactor.get(`GetAllFactor`).then(function (response) {
            dispatch({
                type: types.LISTFACTOR,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllFactor: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function AddEditFactor(obj) {
    return (dispatch) => {
        defaultURLFactor.post(`AddEditFactor`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITFACTOR,
                data: response.data
            });
        }).catch(function (error) {
            console.log("addEditFactor: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function DeleteFactor(ids) {
    return (dispatch) => {
        defaultURLFactor.get(`DeleteFactor?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");

                dispatch({
                    type: types.DELETEFACTOR,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteFactor: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}
export function GetAllPriceLst() {
    return (dispatch) => {
        axiosDocsControlle.get(`GetAllPriceLst`).then(function (response) {
            dispatch({
                type: types.LISTPRICELST,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllPriceLst: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function AddEditPriceLst(obj) {
    return (dispatch) => {
        axiosDocsControlle.post(`AddEditPriceLst`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPRICELST,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditPriceLst: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function DeletePriceLst(ids) {
    return (dispatch) => {
        axiosDocsControlle.get(`DeletePriceLst?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");

                dispatch({
                    type: types.DELETEPRICELST,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeletePriceLst: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

//Client_Comments
export function GetAllClientOpinions() {
    return (dispatch) => {
        defaultURLClientComments.get(`GetAllClientOpinions`).then(function (response) {
            dispatch({
                type: types.LISTCLIENTCOMM,
                data: response.data
            });
        }).catch(function (error) {
            console.log("GetAllClientOpinions: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function AddEditClientsOpinion(obj) {
    return (dispatch) => {
        defaultURLClientComments.post(`AddEditClientOpinions`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITClIENTCOMM,
                data: response.data
            });
        }).catch(function (error) {
            console.log("AddEditClientOpinions: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function DeleteClientsOpinion(ids) {
    return (dispatch) => {
        defaultURLClientComments.get(`DeleteClientOpinions?ids=${ids.toString()}`).then(function (response) {
            if (response.data.payload === true) {
                toastr.success("تم الحذف بنجاح");

                dispatch({
                    type: types.DELETEClIENTCOMM,
                    ids
                });
            } else {
                toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
            }
        }).catch(function (error) {
            console.log("DeleteClientOpinions: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function getCompanyInfo(ids) {
    return (dispatch) => {
        defaultURLCompanyInfo.get(`GetCompanyInfo`).then(function (response) {
            dispatch({
                type: types.COMPANYINFO,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getCompanyInfo: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function addEditCompanyInfo(obj) {
    return (dispatch) => {
        defaultURLCompanyInfo.post(`AddEditCompanyInfo`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCOMPANYINFO,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("addeditCatalogue: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}





export function getAllCategoryType() {
    return (dispatch) => {
        defaultURLCategoryType.get(`GetAllCategoryType`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYTYPE,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function deleteCategoryType(ids) {
    return (dispatch) => {
        defaultURLCategoryType.get(`DeleteCategoryType?id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETECATEGORYTYPE,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("DeleteCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function addeditCategoryType(obj) {
    return (dispatch) => {
        defaultURLCategoryType.post(`AddEditCategoryType`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCATEGORYTYPE,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function getAllCategoryTypeForDrop() {
    return (dispatch) => {
        defaultURLCategoryType.get(`GetAllCategoryType`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYTYPEFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllCategoryGallery() {
    return (dispatch) => {
        defaultURLCategoryGallery.get(`GetAllCategoryGallery`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYGALLERY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function addeditCategoryGallery(obj) {
    return (dispatch) => {
        defaultURLCategoryGallery.post(`AddEditCategoryName`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCATEGORYGALLERY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditCategoryName: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function deleteCategoryGallery(ids) {
    return (dispatch) => {
        defaultURLCategoryGallery.get(`DeleteCategoryGallery?id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETECATEGORYGALLERY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteCategoryGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function getAllCategoryGalleryForDrop() {
    return (dispatch) => {
        defaultURLCategoryGallery.get(`GetAllCategoryGalleryForDrop`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYGALLERYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllCategoryGalleryForDrop: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function getAllCategoryChildGallery() {
    return (dispatch) => {
        defaultURLCategoryChildGallery.get(`GetAllCategoryChildGallery`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYCHILDGALLERY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllCategoryChildGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function addeditCategoryChildGallery(obj) {
    return (dispatch) => {
        defaultURLCategoryChildGallery.post(`AddEditCategoryChildGallery`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCATEGORYCHILDGALLERY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditCategoryChildGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function deleteCategoryChildGallery(ids) {
    return (dispatch) => {
        defaultURLCategoryChildGallery.get(`DeleteCategoryChildGallery?id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETECATEGORYCHILDGALLERY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteCategoryChildGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}





export function getAllCategoryChildGalleryForDrop() {
    return (dispatch) => {
        defaultURLCategoryChildGallery.get(`GetAllCategoryChildGalleryForDrop`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORYCHILDGALLERYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllCategoryChildGalleryForDrop: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function getAllGalleryByType(type) {
    return (dispatch) => {
        defaultURLGallery.get(`GetAllGallery?type=${type}`).then(function (response) {
            dispatch({
                type: types.GALLERYType,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function addeditGallery(obj) {
    return (dispatch) => {
        defaultURLGallery.post(`AddEditGallery`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITGALLERY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function deleteGallery(ids) {
    return (dispatch) => {
        defaultURLGallery.get(`DeleteGallery?id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEGALLERY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}





export function getAllColor() {
    return (dispatch) => {
        defaultURLColors.get(`GetAllColors`).then(function (response) {
            dispatch({
                type: types.GETALLCOLORS,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllColors: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditColors(obj) {
    return (dispatch) => {
        defaultURLColors.post(`AddEditColors`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCOLORS,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditColors: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteColors(ids) {
    return (dispatch) => {
        defaultURLColors.get(`DeleteColors?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETECOLORS,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteColors: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}







export function getAllParentCategory() {
    return (dispatch) => {
        defaultURLCategoryCost.get(`GetAllParentCategory`).then(function (response) {
            dispatch({
                type: types.GETALLPARENTCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllParentCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditParentCategory(obj) {
    return (dispatch) => {
        defaultURLCategoryCost.post(`AddEditParentCategory`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPARENTCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditParentCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteParentCategory(ids) {
    return (dispatch) => {
        defaultURLCategoryCost.get(`DeleteParentCategory?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEPARENTCATEGORY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteParentCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}






export function GetAllProductName() {
    return (dispatch) => {
        defaultURLProductName.get(`GetAllProductName`).then(function (response) {
            dispatch({
                type: types.GETALLPRODUCTNAME,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllProductName: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditProductName(obj) {
    return (dispatch) => {
        defaultURLProductName.post(`AddEditProductName`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPRODUCTNAME,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("addeditCategoryGallery: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteProductName(ids) {
    return (dispatch) => {
        defaultURLProductName.get(`DeleteProductName?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEPRODUCTNAME,
                ids
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}






export function getAllParentProductCategory() {
    return (dispatch) => {
        defaultURLParentProductCategory.get(`GetAllParentProductCategory`).then(function (response) {
            dispatch({
                type: types.GETALLPARENTPRODUCTCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllParentProductCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditParentProductCategory(obj) {
    return (dispatch) => {
        defaultURLParentProductCategory.post(`AddEditParentProductCategory`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPARENTPRODUCTCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditParentProductCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteParentProductCategory(ids) {
    return (dispatch) => {
        defaultURLParentProductCategory.get(`DeleteParentProductCategory?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEPARENTPRODUCTCATEGORY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteParentProductCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllParentProductCategoryForDrop() {
    return (dispatch) => {
        defaultURLParentProductCategory.get(`GetAllParentProductCategory`).then(function (response) {
            dispatch({
                type: types.GETALLPARENTPRODUCTCATEGORYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllParentProductCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function getAllCategory() {
    return (dispatch) => {
        defaultURLCategory.get(`GetAllCategory`).then(function (response) {
            dispatch({
                type: types.GETALLCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function addeditCategory(obj) {
    return (dispatch) => {
        defaultURLCategory.post(`AddEditCategory`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteCategory(ids) {
    return (dispatch) => {
        defaultURLCategory.get(`DeleteCategory?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETECATEGORY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllProductForDrop() {
    return (dispatch) => {
        defaultURLProductName.get(`GetAllProductName`).then(function (response) {
            dispatch({
                type: types.PRODUCTFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function getAllColorForDrop() {
    return (dispatch) => {
        defaultURLColors.get(`GetAllColors`).then(function (response) {
            dispatch({
                type: types.COLORSFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllCategoryForDrop() {
    return (dispatch) => {
        defaultURLCategory.get(`GetAllCategoryForDrop`).then(function (response) {
            dispatch({
                type: types.CATEGORYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function getAllProductInfo() {
    return (dispatch) => {
        defaultURLProduct.get(`GetAllProducts`).then(function (response) {
            dispatch({
                type: types.GETALLPRODUCT,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllProducts: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function addeditProductInfo(obj) {
    return (dispatch) => {
        defaultURLProduct.post(`AddEditProduct`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPRODUCT,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditProduct: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteProductInfo(ids) {
    return (dispatch) => {
        defaultURLProduct.get(`DeleteProduct?id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEPRODUCT,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteProduct: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}






export function getAllParentCategoryForDrop() {
    return (dispatch) => {
        defaultURLCategoryCost.get(`GetAllParentCategoryForDropDown`).then(function (response) {
            dispatch({
                type: types.PARENTCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllParentCategoryForDropDown: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}





export function getAllSubCategory() {
    return (dispatch) => {
        defaultURLCategoryCost.get(`GetAllSubCategory`).then(function (response) {
            dispatch({
                type: types.GETALLSUBCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllSubCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function addeditSubCategory(obj) {
    return (dispatch) => {
        defaultURLCategoryCost.post(`AddEditSubCategory`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITSUBCATEGORY,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditSubCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}

export function deleteSubCategory(ids) {
    return (dispatch) => {
        defaultURLCategoryCost.get(`DeleteSubCategory?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETESUBCATEGORY,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteSubCategory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllSubCategoryForDropDown() {
    return (dispatch) => {
        defaultURLCategoryCost.get(`GetAllSubCategoryForDropDown`).then(function (response) {
            dispatch({
                type: types.GETSUBCATEGORYFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllSubCategoryForDropDown: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllProductWithColor() {
    return (dispatch) => {
        defaultURLProduct.get(`GetAllProductWithColor`).then(function (response) {
            dispatch({
                type: types.GETPRODUCTFORDROP,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllProductWithColor: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function addEditProductIngredient(obj) {
    return (dispatch) => {
        defaultURLProductIngredients.post(`AddEditProductIngredient`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITPRODUCTING,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditProductIngredient: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function deleteProductIngredient(ids) {
    return (dispatch) => {
        defaultURLProductIngredients.get(`DeleteProductIngredient?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEPRODUCTING,
                ids
            });
        }).catch(function (error) {
            console.log("deleteProductIngredient: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllProductIngreditent() {
    return (dispatch) => {
        defaultURLProductIngredients.get(`GetAllProductIngredient`).then(function (response) {
            dispatch({
                type: types.GETALLPRODUCTING,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllProductIngredient: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function getAllDescount() {
    return (dispatch) => {
        defaultURLDiscount.get(`GetAllDescount`).then(function (response) {
            dispatch({
                type: types.GETALLDESCOUNT,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("getAllCategoryType: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}




export function addEditDescount(obj) {
    return (dispatch) => {
        defaultURLDiscount.post(`AddEditDescount`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITDESCOUNT,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditDescount: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function deleteDescount(ids) {
    return (dispatch) => {
        defaultURLDiscount.get(`DeleteDescount?Id=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEDESCOUNT,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteDescount: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}





export function addEditProductIngredientAccess(obj) {
    return (dispatch) => {
        defaultURLProIngredientsAccessory.post(`AddEditProductIngredientAccessory`, obj).then(function (response) {
            toastr.success("تم الحفظ بنجاح");
            dispatch({
                type: types.ADDEDITINGREACCESS,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("AddEditProductIngredientAccessory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}



export function deleteProductIngredientAccess(ids) {
    return (dispatch) => {
        defaultURLProIngredientsAccessory.get(`DeleteProductIngredientAccessory?ids=${ids.toString()}`).then(function (response) {
            dispatch({
                type: types.DELETEINGREACCESS,
                ids
            });
        }).catch(function (error) {
            console.log("DeleteProductIngredientAccessory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });
    };
}


export function getAllProductIngreditentAccess() {
    return (dispatch) => {
        defaultURLProIngredientsAccessory.get(`GetAllProductIngredientAccessory`).then(function (response) {
            dispatch({
                type: types.GETALLINGREACCESS,
                data: response.data.payload
            });
        }).catch(function (error) {
            console.log("GetAllProductIngredientAccessory: ", error);
            toastr.error("يوجد مشكلة برجاء الاتصال بالمسؤول");
        });

    };

}