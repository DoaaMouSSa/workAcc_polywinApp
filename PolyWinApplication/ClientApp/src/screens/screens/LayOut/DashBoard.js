import React, { Component, Fragment } from 'react'; 
import axois from "../../axios/axiosLogin";
import '../../Design/CSS/custom.css';

class DashBoard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            currentLang: window.localStorage.getItem("lang") || "ar",
            fullName: "Ahmed Salah",
            employeeId: 1
        }
    }

    signOut = () => {
        this.props.history.push('/');
        localStorage.clear();
        window.location.reload();
    }

    handleChangeCheck = (e) => {
        this.setState({
            currentLang: e.target.value
        });
        window.localStorage.setItem("lang", e.target.value);

        axois.get(`UpdateLanguage?EmployeeId=${this.state.employeeId}&lang=${e.target.value}`).then(result => {

            window.location.reload();
        });
    }

    render() {

        return (
            <Fragment>
                <div className="content-page">
                    <div className="content">
                        <div className="container-fluid"> 
                            <div className="row">
                                <div className="col-xl-12">
                                    <div className="breadcrumb-holder">
                                        <h1 className="main-title float-left">Dashboard</h1>
                                        <div className="clearfix"></div>
                                    </div> 
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-xs-12 col-md-6 col-lg-6 col-xl-3">
                                    <div className="card-box noradius noborder bg-danger">
                                        <i className="far fa-user float-right text-white"></i>
                                        <h6 className="text-white text-uppercase m-b-20">Users</h6>
                                        <h1 className="m-b-20 text-white counter">487</h1>
                                        <span className="text-white">12 Today</span>
                                    </div>
                                </div>

                                <div className="col-xs-12 col-md-6 col-lg-6 col-xl-3">
                                    <div className="card-box noradius noborder bg-purple">
                                        <i className="fas fa-download float-right text-white"></i>
                                        <h6 className="text-white text-uppercase m-b-20">Downloads</h6>
                                        <h1 className="m-b-20 text-white counter">290</h1>
                                        <span className="text-white">12 Today</span>
                                    </div>
                                </div>

                                <div className="col-xs-12 col-md-6 col-lg-6 col-xl-3">
                                    <div className="card-box noradius noborder bg-warning">
                                        <i className="fas fa-shopping-cart float-right text-white"></i>
                                        <h6 className="text-white text-uppercase m-b-20">Orders</h6>
                                        <h1 className="m-b-20 text-white counter">320</h1>
                                        <span className="text-white">25 Today</span>
                                    </div>
                                </div>

                                <div className="col-xs-12 col-md-6 col-lg-6 col-xl-3">
                                    <div className="card-box noradius noborder bg-info">
                                        <i className="far fa-envelope float-right text-white"></i>
                                        <h6 className="text-white text-uppercase m-b-20">Messages</h6>
                                        <h1 className="m-b-20 text-white counter">58</h1>
                                        <span className="text-white">5 New</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </Fragment>);
    }
}

export default DashBoard;