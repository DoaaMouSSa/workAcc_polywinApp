import React, { Component, Fragment } from 'react';
import { NavLink } from "react-router-dom";
import Logo from "../../Design/img/Polywin Logo@3x.png";
import Avatar2 from "../../Design/img/avatar2.png";
import Avatar3 from "../../Design/img/avatar3.png";
import Avatar4 from "../../Design/img/avatar4.png";
import Admin from "../../Design/img/admin.png";
import Config from "../../Config/Config";
import '../../Design/CSS/custom.css';


class RightMenu extends Component {
    constructor(props) {
        super(props);
        let userType = JSON.parse(sessionStorage.getItem("UserType"));
        let role_id = JSON.parse(sessionStorage.getItem("role_id"));
        this.state = {
            fullName: "Ahmed Salah",
            employeeId: 1,
            isOpen: false,
            currentLink: 0,
            role_id:role_id,
            userType: userType,
            headerMenu: true
        }
    }

    handleClick = (e) => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }

    handleLink = (currentLink) => {
        if (this.state.currentLink === currentLink) {
            this.setState({
                currentLink: 0
            });
        }
        else {
            this.setState({
                currentLink
            });
        }
    }
    clearRole() {
        localStorage.clear();
    }
    handleMenuClick = () => {

        if (this.state.headerMenu) {
            var body = document.getElementById("body");
            body.classList.add("adminbody-void");

            var main = document.getElementById("main");
            main.classList.add("enlarged");

        } else {

            var body = document.getElementById("body");
            body.classList.remove("adminbody-void");

            var main = document.getElementById("main");
            main.classList.remove("enlarged");
        }

        this.setState({
            headerMenu: !this.state.headerMenu
        });
    }


    render() {
        return (
            <Fragment>
                {/*<!-- top bar navigation -->*/}
                <div className="headerbar">
                    {/* <!-- LOGO -->*/}
                    <div className="headerbar-left">
                        <a href="index-2.html" className="logo">
                            <img alt="Logo" src={Logo} />
                        </a>
                    </div>
                    <nav className="navbar-custom">
                        <ul className="list-inline float-right mb-0">
                            {/*<li className="list-inline-item dropdown notif">*/}
                            {/*    <a className="nav-link dropdown-toggle arrow-none" data-toggle="dropdown" href="#" aria-haspopup="false" aria-expanded="false">*/}
                            {/*        <i className="far fa-envelope"></i>*/}
                            {/*        <span className="notif-bullet"></span>*/}
                            {/*    </a>*/}
                            {/*    <div className="dropdown-menu dropdown-menu-right dropdown-arrow dropdown-arrow-success dropdown-lg">*/}
                            {/*        */}{/* <!-- item-->*/}
                            {/*        <div className="dropdown-item noti-title">*/}
                            {/*            <h5>*/}
                            {/*                <small>*/}
                            {/*                    <span className="label label-danger pull-xs-right">12</span>Mailbox</small>*/}
                            {/*            </h5>*/}
                            {/*        </div>*/}
                            {/*        */}{/*<!-- item-->*/}
                            {/*        <a href="mail-all.html" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <b>John Doe</b>*/}
                            {/*                <span>New message received</span>*/}
                            {/*                <small className="text-muted">3 minutes ago</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/* <!-- item-->*/}
                            {/*        <a href="mail-all.html" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <b>Michael Smith</b>*/}
                            {/*                <span>New message received</span>*/}
                            {/*                <small className="text-muted">18 minutes ago</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/* <!-- item-->*/}
                            {/*        <a href="mail-all.html" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <b>John Lenons</b>*/}
                            {/*                <span>New message received</span>*/}
                            {/*                <small className="text-muted">Yesterday, 18:27</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/*   <!-- All-->*/}
                            {/*        <a href="mail-all.html" className="dropdown-item notify-item notify-all">*/}
                            {/*            View All Messages*/}
                            {/*         </a>*/}
                            {/*    </div>*/}
                            {/*</li>*/}
                            <li className="list-inline-item dropdown notif">
                                <a className="nav-link dropdown-toggle arrow-none" data-toggle="dropdown" href="#" aria-haspopup="false" aria-expanded="false">
                                    <i className="far fa-bell"></i>
                                    <span className="notif-bullet"></span>
                                </a>
                               {/* <div className="dropdown-menu dropdown-menu-right dropdown-arrow dropdown-arrow-success dropdown-lg"*/}
                                    {/*<!-- item-->*/}
                            {/*        <div className="dropdown-item noti-title">*/}
                            {/*            <h5>*/}
                            {/*                <small>*/}
                            {/*                    <span className="label label-danger pull-xs-right">5</span>Allerts</small>*/}
                            {/*            </h5>*/}
                            {/*        </div>*/}
                            {/*        */}{/*<!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <div className="notify-icon bg-faded">*/}
                            {/*                <img src={Avatar2} alt="img" className="rounded-circle img-fluid" />*/}
                            {/*            </div>*/}
                            {/*            <p className="notify-details">*/}
                            {/*                <b>John Doe</b>*/}
                            {/*                <span>User registration</span>*/}
                            {/*                <small className="text-muted">3 minutes ago</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/*  <!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <div className="notify-icon bg-faded">*/}
                            {/*                <img src={Avatar3} alt="img" className="rounded-circle img-fluid" />*/}
                            {/*            </div>*/}
                            {/*            <p className="notify-details">*/}
                            {/*                <b>Michael Cox</b>*/}
                            {/*                <span>Task 2 completed</span>*/}
                            {/*                <small className="text-muted">12 minutes ago</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/*<!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <div className="notify-icon bg-faded">*/}
                            {/*                <img src={Avatar4} alt="img" className="rounded-circle img-fluid" />*/}
                            {/*            </div>*/}
                            {/*            <p className="notify-details">*/}
                            {/*                <b>Michelle Dolores</b>*/}
                            {/*                <span>New job completed</span>*/}
                            {/*                <small className="text-muted">35 minutes ago</small>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*        */}{/* <!-- All-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item notify-all">*/}
                            {/*            View All Allerts*/}
                            {/*</a>*/}

                            {/*    </div>*/}
                            </li>


                            <li className="list-inline-item dropdown notif">
                                <a className="nav-link dropdown-toggle arrow-none" data-toggle="dropdown" href="#" aria-haspopup="false" aria-expanded="false">
                                    <i className="fas fa-cog"></i>
                                </a>

                            {/*    <div className="dropdown-menu dropdown-menu-right dropdown-arrow dropdown-arrow-success dropdown-sm">*/}
                            {/*        */}{/*<!-- item-->*/}
                            {/*        <div className="dropdown-item noti-title">*/}
                            {/*            <h5>*/}
                            {/*                <small>Settings</small>*/}
                            {/*            </h5>*/}
                            {/*        </div>*/}

                            {/*        */}{/* <!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <i className="fas fa-cog"></i>*/}
                            {/*                <b>Settings 1</b>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}

                            {/*        */}{/*   <!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <i className="fas fa-cog"></i>*/}
                            {/*                <b>Settings 2</b>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}

                            {/*        */}{/*  <!-- item-->*/}
                            {/*        <a href="#" className="dropdown-item notify-item">*/}
                            {/*            <p className="notify-details ml-0">*/}
                            {/*                <i className="fas fa-cog"></i>*/}
                            {/*                <b>Settings 3</b>*/}
                            {/*            </p>*/}
                            {/*        </a>*/}
                            {/*    </div>*/}
                            </li>
                            <li className="list-inline-item dropdown notif">
                                <a className="nav-link dropdown-toggle nav-user" data-toggle="dropdown" href="#" aria-haspopup="false" aria-expanded="false">
                                    <img src={Admin} alt="Profile image" className="avatar-rounded" />
                                </a>
                                <div className="dropdown-menu dropdown-menu-right profile-dropdown ">
                                    {/*  <!-- item-->*/}
                                    <div className="dropdown-item noti-title">
                                        <h5 className="text-overflow">
                                            <small>مرحبا</small>
                                        </h5>
                                    </div>

                                    {/* <!-- item-->*/}
                                    {/*<a href="profile.html" className="dropdown-item notify-item">*/}
                                    {/*    <i className="fas fa-user"></i>*/}
                                    {/*    <span>Profile</span>*/}
                                    {/*</a>*/}

                                    {/* <!-- item-->*/}
                                    <a href="#" className="dropdown-item notify-item" onClick={this.clearRole()}>
                                        <i className="fas fa-power-off"></i>
                                        <span>تسجيل الخروج</span>
                                    </a>
                                </div>
                            </li>

                        </ul>

                        <ul className="list-inline menu-left mb-0">
                            <li className="float-left">
                                <button className="button-menu-mobile open-left" onClick={this.handleMenuClick}>
                                    <i className="fas fa-bars"></i>
                                </button>
                            </li>
                        </ul>
                    </nav>
                </div>
                {/*   <!-- End Navigation -->*/}

                {/*<!-- Left Sidebar -->*/}
                <div className="left main-sidebar">
                    <div className="sidebar-inner leftscroll">
                        <div id="sidebar-menu">
                            <ul>
                                <li className="submenu">
                                    {/*<a href="index-2.html">*/}
                                    {/*    <i className="fas fa-bars"></i>*/}
                                    {/*    <span> Dashboard </span>*/}
                                    {/*</a>*/}
                                    <NavLink to="/System/Dashboard">
                                        <i className="fas fa-bars"></i>
                                        <span>الرئيسيه</span>
                                    </NavLink>
                                </li>
                                {
                                    this.state.userType == 1 ?
                                        <li className="submenu" onClick={() => this.handleLink(1)}>
                                            <a id="tables" style={{ cursor: 'pointer' }} className={this.state.currentLink === 1 ? "subdrop" : ""}>
                                                <i className="fas fa-table"></i>
                                                <span>  الحسابات الدخول على النظام</span>
                                                <span className="menu-arrow"></span>
                                            </a>
                                            <ul className="list-unstyled" style={{ display: this.state.currentLink === 1 ? "block" : "none" }}>
                                                <li>
                                                    <NavLink to="/System/Accounts">
                                                        <span> تفعيل الحسابات الدخول</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ActiveUnActiveAccount">
                                                        <span> إيقاف / تفعيل الحساب</span>
                                                    </NavLink>
                                                </li>
                                            </ul>
                                        </li>
                                        : null
                                }
                                {
                                    this.state.userType == 1 ?
                                        <li className="submenu" onClick={() => this.handleLink(2)}>
                                            <a style={{ cursor: 'pointer' }} className={this.state.currentLink === 2 ? "subdrop" : ""}>
                                                <i className="fas fa-laptop"></i>
                                                <span> بيانات الادخال </span>
                                                <span className="menu-arrow"></span>
                                            </a>
                                            <ul className="list-unstyled" style={{ display: this.state.currentLink === 2 ? "block" : "none" }}>
                                                <li>
                                                    <NavLink to="/System/Messages">
                                                        <span>رسائل العملاء</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/Agents">
                                                        <span>الوكلاء</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/CompanyInfo">
                                                        <span> بيانات الشركة</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/Descount">
                                                        <span> نسبة الخصم</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/CategoryType">
                                                        <span> أنواع الملفات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/CategoryGallery">
                                                        <span> الأقسام الرئيسية</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/CategoryChildGallery">
                                                        <span> الأقسام الفرعية</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/GalleryImage">
                                                        <span> تسجيل المعرض من نوع صور</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/GallaryFile">
                                                        <span> تسجيل المعرض من نوع ملفات</span>
                                                    </NavLink>
                                                </li>
                                                {/*<li>*/}
                                                {/*    <NavLink to="/System/GallaryVideo">*/}
                                                {/*        <span> تسجيل المعرض من نوع فيديوهات</span>*/}
                                                {/*    </NavLink>*/}
                                                {/*</li>*/}
                                                <li>
                                                    <NavLink to="/System/Colors">
                                                        <span> تسجيل الألوان</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ProductName">
                                                        <span> تسجيل أسماء المنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ParentProductCategory">
                                                        <span> تسجيل القسم العام للمنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/Category">
                                                        <span> تسجيل أقسام المنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ProductInfo">
                                                        <span> تسجيل بيانات المنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ParentCategory">
                                                        <span>أنواع المنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ChildCategory">
                                                        <span>تفاصيل المنتجات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ProductIngredient">
                                                        <span>مكونات المنتج جزء القطاعات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/ProductIngredientAccessory">
                                                        <span>مكونات المنتج جزء الاكسسوارات</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/DataSheet">
                                                        <span> الداتا شيت</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/Catalogue">
                                                        <span> الكاتالوج</span>
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <NavLink to="/System/Factor">
                                                        <span>التخصيمات</span>
                                                    </NavLink>
                                                </li>
                                                {/* <li>
                                                    <NavLink to="/System/PriceLst">
                                                        <span>قائمه الاسعار</span>
                                                    </NavLink>
                                                </li> */}
                                                <li>
                                                    <NavLink to="/System/ClientComments">
                                                        <span>آراء العملاء</span>
                                                    </NavLink>
                                                </li>
                                            </ul>
                                        </li> : null
                                }
                                            {this.state.role_id === 5 ?
                                                <li>
                                                    <NavLink to="/System/Supplier">
                                                        <span> الموردين</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {this.state.role_id === 5 ?
                                                <li>
                                                    <NavLink to="/System/ItemType">
                                                        <span>  الوحدات</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {(this.state.role_id == 5 || this.state.role_id == 3) ?
                                                <li>
                                                    <NavLink to="/System/Store">
                                                        <span> المخزن</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {this.state.role_id === 5 ?

                                                <li>
                                                    <NavLink to="/System/Currency">
                                                        <span>العملات</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {this.state.role_id === 5 ?
                                                <li>
                                                    <NavLink to="/System/Bank">
                                                        <span> الخزينه الرئيسيه</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {(this.state.role_id === 5 || this.state.role_id === 1) ?
                                                <li>
                                                    <NavLink to="/System/Purchase">
                                                        <span> المشتريات</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {this.state.role_id === 5 ?
                                                <li>
                                                    <NavLink to="/System/Banks">
                                                        <span> البنوك</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                                            {this.state.role_id === 5 ?
                                                <li>
                                                    <NavLink to="/System/Employee">
                                                        <span> المشرفين</span>
                                                    </NavLink>
                                                </li> : null
                                            }
                               
                            </ul>
                            
                            <div className="clearfix"></div>

                        </div>

                        <div className="clearfix"></div>

                    </div>

                </div>
                {/*     <!-- End Sidebar -->*/}

                {/*<div className="content-page">*/}

                {/*    */}{/*   <!-- Start content -->*/}
                {/*    <div className="content">*/}

                {/*        <div className="container-fluid">*/}

                {/*            <div className="row">*/}
                {/*                <div className="col-xl-12">*/}
                {/*                    <div className="breadcrumb-holder">*/}
                {/*                        <h1 className="main-title float-left">Cards</h1>*/}
                {/*                        <ol className="breadcrumb float-right">*/}
                {/*                            <li className="breadcrumb-item">Home</li>*/}
                {/*                            <li className="breadcrumb-item active">Cards</li>*/}
                {/*                        </ol>*/}
                {/*                        <div className="clearfix"></div>*/}
                {/*                    </div>*/}
                {/*                </div>*/}
                {/*            </div>*/}
                {/*            */}{/* <!-- end row -->*/}

                {/*            <div className="alert alert-success" role="alert">*/}
                {/*                <h4 className="alert-heading">Documentation</h4>*/}
                {/*                <p>A card is a flexible and extensible content container. It includes options for headers and footers, a wide variety of content, contextual background colors, and powerful display options. If you're familiar with Bootstrap 3, cards*/}
                {/*            replace our old panels, wells, and thumbnails. Similar functionality to those components is available as modifier classes for cards.You can find examples and documentation about Bootstrap Cards here: <a target="_blank" href="http://getbootstrap.com/docs/4.3/components/card/">Bootstrap Cards Documentation</a></p>*/}
                {/*            </div>*/}

                {/*            <div className="row">*/}

                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Card Example</h3>*/}
                {/*                    Below is an example of a basic card with mixed content and a fixed width. Cards have no fixed width to start, so they naturally fill the full width of its parent element. This is easily customized with our various*/}
                {/*                    <a target="_blank" href="http://getbootstrap.com/docs/4.3/components/card/#sizing">sizing options*/}
                {/*                        </a>*/}
                {/*                        </div>*/}
                {/*                        <div className="card-body">*/}
                {/*                            <div className="card">*/}
                {/*                                <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                    <a href="#" className="btn btn-primary">Go somewhere</a>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/*  <!-- end card-->*/}
                {/*                </div>*/}

                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Cards with multiple content types</h3>*/}
                {/*                    Mix and match multiple content types to create the card you need, or throw everything in there. Shown below are image styles, blocks, text styles, and a list group-all wrapped in a fixed-width card. <a target="_blank"*/}
                {/*                                href="http://getbootstrap.com/docs/4.3/components/card/#kitchen-sink">(more*/}
                {/*                            info)</a>*/}
                {/*                        </div>*/}

                {/*                        <div className="card-body">*/}
                {/*                            <div className="card">*/}
                {/*                                <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                                <ul className="list-group list-group-flush">*/}
                {/*                                    <li className="list-group-item">Vestibulum at eros</li>*/}
                {/*                                </ul>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <a href="#" className="card-link">Card link</a>*/}
                {/*                                    <a href="#" className="card-link">Another link</a>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}

                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/*  <!-- end card-->*/}
                {/*                </div>*/}
                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Header and footer</h3>*/}
                {/*                    Add an optional header and/or footer within a card. <a target="_blank" href="http://getbootstrap.com/docs/4.3/components/card/#header-and-footer">(more*/}
                {/*                                info)</a>*/}
                {/*                        </div>*/}
                {/*                        <div className="card-body">*/}
                {/*                            <div className="card">*/}
                {/*                                <div className="card-header">*/}
                {/*                                    Card Header Content*/}
                {/*                        </div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Special title treatment</h4>*/}
                {/*                                    <p className="card-text">With supporting text below as a natural lead-in to additional content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                    <p className="card-text">With supporting text below as a natural lead-in to additional content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                    <p className="card-text">With supporting text below as a natural lead-in to additional content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content. Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                    <a href="#" className="btn btn-primary">Go somewhere</a>*/}
                {/*                                </div>*/}
                {/*                                <div className="card-footer text-muted">*/}
                {/*                                    Card footer content*/}
                {/*                        </div>*/}
                {/*                            </div>*/}

                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/*    <!-- end card-->*/}
                {/*                </div>*/}
                {/*            </div>*/}
                {/*            <div className="row">*/}
                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Card groups</h3>*/}
                {/*                    Use card groups to render cards as a single, attached element with equal width and height columns. Card groups use <i>display: flex;</i> to achieve their uniform sizing.*/}
                {/*                </div>*/}
                {/*                        <div className="card-body">*/}
                {/*                            <div className="card-group">*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This card has supporting text below as a natural lead-in to additional content.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}

                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/* <!-- end card-->*/}
                {/*                </div>*/}


                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Card decks</h3>*/}
                {/*                    Need a set of equal width and height cards that aren't attached to one another? Use card decks.*/}
                {/*                </div>*/}

                {/*                        <div className="card-body">*/}


                {/*                            <div className="card-deck">*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                                <div className="card">*/}
                {/*                                    <img className="card-img-top" src="https://via.placeholder.com/300x250" alt="Card image cap" />*/}
                {/*                                    <div className="card-body">*/}
                {/*                                        <h4 className="card-title">Card title</h4>*/}
                {/*                                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p>*/}
                {/*                                    </div>*/}
                {/*                                    <div className="card-footer">*/}
                {/*                                        <small className="text-muted">Last updated 3 mins ago</small>*/}
                {/*                                    </div>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/* <!-- end card-->*/}
                {/*                </div>*/}


                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="fas fa-square"></i> Background and color</h3>*/}
                {/*                    Use <a target="_blank" href="http://getbootstrap.com/docs/4.3/utilities/colors/">text and background*/}
                {/*                        utilities</a> to change the appearance of a card.*/}
                {/*                </div>*/}

                {/*                        <div className="card-body">*/}

                {/*                            <div className="card text-white bg-primary mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Primary card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-secondary mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Secondary card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-success mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Success card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-danger mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Danger card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-warning mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Warning card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-info mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Info card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card bg-light mb-3">*/}
                {/*                                <div className="card-header text-black">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Light card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card text-white bg-dark mb-3">*/}
                {/*                                <div className="card-header text-white">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Dark card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}

                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/* <!-- end card-->*/}
                {/*                </div>*/}

                {/*                <div className="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6">*/}
                {/*                    <div className="card mb-3">*/}
                {/*                        <div className="card-header">*/}
                {/*                            <h3><i className="far fa-square"></i> Border</h3>*/}
                {/*                    Use <a target="_blank" href="http://getbootstrap.com/docs/4.3/utilities/borders/">border utilities</a> to change just the border-color of a card. Note that you can put*/}
                {/*                    <i>.text- </i> classes on the parent <i>.card</i>.*/}
                {/*                </div>*/}

                {/*                        <div className="card-body">*/}

                {/*                            <div className="card border-primary mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-primary">*/}
                {/*                                    <h4 className="card-title">Primary card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-secondary mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-secondary">*/}
                {/*                                    <h4 className="card-title">Secondary card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-success mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-success">*/}
                {/*                                    <h4 className="card-title">Success card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-danger mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-danger">*/}
                {/*                                    <h4 className="card-title">Danger card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-warning mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-warning">*/}
                {/*                                    <h4 className="card-title">Warning card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-info mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-info">*/}
                {/*                                    <h4 className="card-title">Info card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-light mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body">*/}
                {/*                                    <h4 className="card-title">Light card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}
                {/*                            <div className="card border-dark mb-3">*/}
                {/*                                <div className="card-header">Header</div>*/}
                {/*                                <div className="card-body text-dark">*/}
                {/*                                    <h4 className="card-title">Dark card title</h4>*/}
                {/*                                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>*/}
                {/*                                </div>*/}
                {/*                            </div>*/}

                {/*                        </div>*/}
                {/*                    </div>*/}
                {/*                    */}{/*       <!-- end card-->*/}
                {/*                </div>*/}

                {/*            </div>*/}




                {/*        </div>*/}
                {/*        */}{/*   <!-- END container-fluid -->*/}

                {/*    </div>*/}
                {/*    */}{/* <!-- END content -->*/}

                {/*</div>*/}
                {/*  <!-- END content-page -->*/}

                {/*<footer className="footer">*/}
                {/*    <span className="text-right">*/}
                {/*        Copyright <a target="_blank" href="#">PolyWin</a>*/}
                {/*    </span>*/}
                {/*    <span className="float-right">*/}
                {/*        Powered by <a target="_blank" href="https://bootstrap24.com/" title="Download free Bootstrap templates"><b>Bootstrap24.com</b></a>*/}
                {/*    </span>*/}
                {/*</footer>*/}
            </Fragment>);
    }
}

export default RightMenu;