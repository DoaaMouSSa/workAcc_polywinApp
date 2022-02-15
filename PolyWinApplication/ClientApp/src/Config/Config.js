import CryptoJS from 'crypto-js';

const IsAllow = (code) => {

    let objUserInfo = JSON.parse(localStorage.getItem("userInfo"));
    let userType = JSON.parse(localStorage.getItem("userType"));
    let role_id = JSON.parse(localStorage.getItem("role_id"));
    if (role_id == 1) {
        return true;
    }
    if (userType == 1) {
        return true;
    } else if (userType == 2) {
        //let permission = JSON.parse(localStorage.getItem("Permission"));

        //const allow = permission.findIndex(x => x === code);

        //if (allow > -1) {
        //    return true;
        //} else {
        //    return false;
        //}
        return true;
    }
}

const encrypt = (code) => {
    // PROCESS
    const encryptedWord = CryptoJS.enc.Utf8.parse(code);
    const encrypted = CryptoJS.enc.Base64.stringify(encryptedWord);
    return encrypted;

}


const decrypt = (code) => {

    // PROCESS
    const encryptedWord = CryptoJS.enc.Base64.parse(code); // encryptedWord via Base64.parse()
    const decrypted = CryptoJS.enc.Utf8.stringify(encryptedWord); // decrypted encryptedWord via Utf8.stringify() 
    return decrypted;
}

const defaultURLAPI = () => {
    return "/api/UserInfo"
}
const defaultURLDataSheet = () => {
    return "/api/DataSheets"
}
const defaultURLSupplier = () => {
    return "/api/Supplier"
}
const defaultURLPurchase = () => {
    return "/api/Purchase"
}
const defaultURLItemType = () => {
    return "/api/ItemTypes"
}
const defaultURLStore = () => {
    return "/api/Store"
}
const defaultURLBank = () => {
    return "/api/Banque"
}
const defaultURLMessage = () => {
    return "/api/Message"
}
const defaultURLCurrency = () => {
    return "/api/Currency"
}
const defaultURLProductName = () => {
    return "/api/ProductName"
}
const defaultURLAPITOKEN = () => {
    return "PolyWinLogIn"
}
const defaultURLAgent = () => {
    return "/api/Agent"
}
const defaultURLCompanyInfo = () => {
    return "/api/CompanyInfo"
}
const defaultURLDiscount= () => {
    return "/api/Discount"
}
const defaultURLParentProductCategory= () => {
    return "/api/ParentProductCategory"
}
const defaultURLCategoryType= () => {
    return "/api/CategoryType"
}
const defaultURLCategoryGallery= () => {
    return "/api/CategoryGallery"
}
const defaultURLCategoryChildGallery= () => {
    return "/api/CategoryChildGallery"
}
const defaultURLCategory= () => {
    return "/api/Category"
}
const defaultURLGallery= () => {
    return "/api/Gallery"
}
const defaultURLColors= () => {
    return "/api/Colors"
}
const defaultURLProduct= () => {
    return "/api/Product"
}
const defaultURLCategoryCost= () => {
    return "/api/CategoryCost"
}
const defaultURLProductIngredients= () => {
    return "/api/ProductIngredients"
}
const defaultURLProIngredientsAccessory= () => {
    return "/api/ProductIngredientAccessory"
}
const defaultURLCatalog= () => {
    return "/api/Catalog"
}
const defaultURLFactor= () => {
    return "/api/Factoring"
}
const defaultURLClientComments= () => {
    return "/api/ClientComments"
}
const defaultURLBankOut = () => {
    return "/api/Bank"
}
const defaultURLPayments = () => {
    return "/api/PaymentContoller"
}
const defaultURLRole = () => {
    return "/api/Role"
}
const defaultURLEmployee = () => {
    return "/api/Employee"
}
const defaultURLPurchaseInvoice = () => {
    return "/api/PurchaseInvoice"
}
export default { IsAllow, encrypt, decrypt, defaultURLAPI, defaultURLAPITOKEN,defaultURLDataSheet
    ,defaultURLMessage,defaultURLSupplier,defaultURLPurchase,defaultURLItemType,defaultURLStore
    , defaultURLBank, defaultURLCurrency, defaultURLProductName, defaultURLAgent,
    defaultURLCompanyInfo,defaultURLDiscount,defaultURLParentProductCategory,defaultURLCategoryType,
    defaultURLCategoryGallery,defaultURLCategoryChildGallery,defaultURLGallery,
    defaultURLColors,defaultURLProduct,defaultURLCategoryCost,defaultURLProductIngredients,
    defaultURLProIngredientsAccessory,defaultURLCatalog,defaultURLFactor,
    defaultURLClientComments, defaultURLCategory, defaultURLPayments, defaultURLBankOut
,defaultURLRole,defaultURLEmployee,defaultURLPurchaseInvoice
};