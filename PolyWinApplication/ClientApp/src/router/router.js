import React, { lazy, Suspense } from "react";
import { Switch, Route, BrowserRouter as Router } from "react-router-dom";
import Loading from '../screens/LoadingPage/LoadingPage';

//layOut
const LayOut = lazy(() => import("../screens/LayOut/LayOut"));

// pages
const DashBoard = lazy(() => import("../screens/LayOut/DashBoard"));
//const DashBoardStore = lazy(() => import("../screens/LayOut/DashBoardStore"));

const Accounts = lazy(() => import("../screens/Accounts/Accounts"));
const Products = lazy(() => import("../screens/Products/Products"));
const PurchaseOrder = lazy(() => import("../screens/PurchaseOrder/PurchaseOrder"));
const PurchaseOrderAddEdit = lazy(() => import("../screens/PurchaseOrder/PurchaseOrderAddEdit"));
const Login = lazy(() => import("../components/Login/Login"));
const DataSheet = lazy(() => import("../screens/DataSheet/DataSheet"));
const Catalogue = lazy(() => import("../screens/Catalogue/Catalogue"));
const Factor = lazy(() => import("../screens/Factor/Factor"));
const Agents = lazy(() => import("../screens/Agents/Agents"));
const PriceLst = lazy(() => import("../screens/PriceLst/PriceLst"));
const ClientComments = lazy(() => import("../screens/ClientComments/ClientComments"));
const Employee = lazy(() => import("../screens/Employee/Employee"));
const CompanyInfo = lazy(() => import("../screens/CompanyInfo/CompanyInfo"));
const CategoryType = lazy(() => import("../screens/CategoryType/CategoryType"));
const CategoryGallery = lazy(() => import("../screens/CategoryGallery/CategoryGallery"));
const GalleryImage = lazy(() => import("../screens/GallaryFileType/GallaryTypeImages"));
const GallaryFile = lazy(() => import("../screens/GallaryFileType/GallaryTypeFile"));
const GallaryVideo = lazy(() => import("../screens/GallaryFileType/GallaryTypeVideo"));
const Colors = lazy(() => import("../screens/Colors/Colors"));
const ParentCategory = lazy(() => import("../screens/ParentCategory/ParentCategory"));
const ProductName = lazy(() => import("../screens/ProductName/ProductName"));
const ProductInfo = lazy(() => import("../screens/ProductInfo/ProductInfo"));
const Category = lazy(() => import("../screens/Category/Category"));
const ChildCategory = lazy(() => import("../screens/ChildCategory/ChildCategory"));
const ProductIngredient = lazy(() => import("../screens/ProductIngredient/ProductIngredient"));
const ProductIngredientAccessory = lazy(() => import("../screens/ProductIngredient/ProductIngredientAccessory"));
const Descount = lazy(() => import("../screens/Descount/Descount"));
const ParentProductCategory = lazy(() => import("../screens/ParentProductCategory/ParentProductCategory"));
const CategoryChildGallery = lazy(() => import("../screens/CategoryChildGallery/CategoryChildGallery"));
const Supplier = lazy(() => import("../screens/Supplier/Suppliers"));
const Store = lazy(() => import("../screens/Store/Store"));
const ItemType = lazy(() => import("../screens/ItemType/ItemType"));
const Messages = lazy(() => import("../screens/Messages/Messages"));
const Bank = lazy(() => import("../screens/Bank/Bank"));
const Purchase = lazy(() => import("../screens/Purchase/Purchase"));
const Currency = lazy(() => import("../screens/Currency/Currency"));
const MainPurchase = lazy(() => import("../screens/MainPurchase/MainPurchase"));
const ActiveUnActiveAccount = lazy(() => import("../screens/Accounts/ActiveUnActiveAccount"));
const Banks = lazy(() => import("../screens/Banks/Banks"));


const RouterDocument = () => {
    return (
        <Suspense fallback={<Loading />}>
            <Router>
                <Switch>
                    <Route path="/Login" component={Login} />
                    {/*<Route exact path="/index-1.html" render={() => { window.location.href = "index-1.html" }} />*/}
                    <LayOut>
                        <Switch>
                            <Route path="/System/DashBoard" component={DashBoard} />
                            {/*<Route path="/System/DashBoardStore" component={DashBoardStore} />*/}
                            <Route path="/System/Accounts" component={Accounts} />
                            <Route path="/System/DataSheet" component={DataSheet} />
                            <Route path="/System/Catalogue" component={Catalogue} />
                            <Route path="/System/PriceLst" component={PriceLst} />
                            <Route path="/System/ClientComments" component={ClientComments} />
                            <Route path="/System/ActiveUnActiveAccount" component={ActiveUnActiveAccount} />
                            <Route path="/System/Factor" component={Factor} />
                            <Route path="/System/CompanyInfo" component={CompanyInfo} />
                            <Route path="/System/Products" component={Products} />
                            <Route path="/System/PurchaseOrder" component={PurchaseOrder} />
                            <Route path="/System/CategoryType" component={CategoryType} />
                            <Route path="/System/CategoryGallery" component={CategoryGallery} />
                            <Route path="/System/ChildCategory" component={ChildCategory} />
                            <Route path="/System/GalleryImage" component={GalleryImage} />
                            <Route path="/System/GallaryFile" component={GallaryFile} />
                            <Route path="/System/GallaryVideo" component={GallaryVideo} />
                            <Route path="/System/Colors" component={Colors} />
                            <Route path="/System/ProductName" component={ProductName} />
                            <Route path="/System/ParentCategory" component={ParentCategory} />
                            <Route path="/System/ProductInfo" component={ProductInfo} />
                            <Route path="/System/Category" component={Category} />
                            <Route path="/System/Descount" component={Descount} />
                            <Route path="/System/ProductIngredientAccessory" component={ProductIngredientAccessory} />
                            <Route path="/System/ProductIngredient" component={ProductIngredient} />
                            <Route path="/System/ParentProductCategory" component={ParentProductCategory} />
                            <Route path="/System/CategoryChildGallery" component={CategoryChildGallery} />
                            <Route path="/System/PurchaseOrderAddEdit/:id" component={PurchaseOrderAddEdit} />
                            <Route path="/System/Supplier" component={Supplier} />
                            <Route path="/System/Store" component={Store} />
                            <Route path="/System/ItemType" component={ItemType} />
                            <Route path="/System/Bank" component={Bank} />
                            <Route path="/System/Employee" component={Employee} />
                            <Route path="/System/Purchase" component={Purchase} />
                            <Route path="/System/MainPurchase" component={MainPurchase} />
                            <Route path="/System/Currency" component={Currency} />
                            <Route path="/System/Messages" component={Messages} />
                            <Route path="/System/Agents" component={Agents} />
                            <Route path="/System/Banks" component={Banks} />
                        </Switch>
                    </LayOut>
                </Switch>
            </Router>
        </Suspense>
    );
};

export default RouterDocument;