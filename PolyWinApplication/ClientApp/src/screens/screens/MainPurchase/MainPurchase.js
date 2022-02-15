import React, { Component, Fragment } from 'react';
import axois from "../../axios/axiosLogin";
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import '../../Design/CSS/custom.css';

class MainDashBoard extends Component {
    constructor(props) {
        super(props);

        this.state = {
                countSup:0,
        }
    }
    componentDidMount() {
    }
     // initial value of state


    render() {

        return (
            <Fragment>
                <div className="content-page">
                    <div className="content">
                        <div className="container-fluid">
                            <div className="row">
                                <div className="col-xl-12">
                                    <div className="breadcrumb-holder">
                                        <h1 className="main-title float-left">الرئيسية</h1>
                                        <div className="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-xs-12 col-md-6 col-lg-6 col-xl-3">
                                    <div className="card-box noradius noborder bg-danger">
                                        <i className="far fa-user float-right text-white"></i>
                                        <h6 className="text-white text-uppercase m-b-20">المودرين</h6>
                                        <h1 className="m-b-20 text-white counter">
                                        {/*    {this.setState({*/}
                                        {/*//    obj.countSup:this.props.ListProductNameForDrop*/}
                                        {/*});*/}
                                        {/*    }*/}
                                            </h1>
                                    {/*    <span className="text-white">12 Today</span>*/}
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

const mapStateToProps = (state, ownProps) => ({
    countSup: state.reduces.CountSupplier
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(MainDashBoard);