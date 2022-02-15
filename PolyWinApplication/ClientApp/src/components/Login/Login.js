import React, { Component, Fragment } from 'react';
import { Spinner, Button } from 'react-bootstrap';
import Wave from "../../Design/img/wave.png";
import Bg from "../../Design/img/bg.svg";
import Avatar from "../../Design/img/avatar.svg";
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import toastr from 'toastr';
import bgLogin from "../../Design/img/1.jpg";
import '../../Design/CSS/App.css';

class Login extends Component {

    constructor(props) {
        super(props);

        this.state = {
            userName: "",
            password: "",
            isLoading: false,
            isLoadingEmp:false
        }
    }


    //componentWillReceiveProps(nextState, prevState) {
    //    if (nextState.role && nextState.role !== "") {

    //        window.localStorage.setItem("role_ide", nextState.role);

    //        this.setState({
    //            isLoading: false
    //        });

    //        this.props.history.push("/System/Dashboard");

    //        window.location.reload();

    //    } else {
    //        this.setState({
    //            isLoading: false
    //        });
    //    }
    //};
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.token && nextState.token !== "") {

            window.sessionStorage.setItem("token", nextState.token);

            this.setState({
                isLoading: false
            });

            this.props.history.push("/System/DashBoard");

            window.location.reload();

        } else {
            this.setState({
                isLoading: false,
            });
        }
    };
    handleLogin = () => {
         if (this.state.userName !== "" && this.state.password !== "") {
             this.setState({
                 isLoading: true
             });
             const obj = {
                 userName: this.state.userName,
                 password: this.state.password
             }
             this.props.actions.login(obj);
         } else {
             toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
         }
     }
    handleLoginForSystem = () => {
        if (this.state.userName !== "" && this.state.password !== "") {
            this.setState({
                isLoadingEmp: true
            });
            const objLogin = {
                name: this.state.userName,
                password: this.state.password
            }
            this.props.actions.loginForEmployees(objLogin);
            this.props.history.push("/System/Dashboard");
        } else {
            toastr.error("خطأ فى اسم المستخدم او كلمة المرور");
            this.props.history.push("/Login");
        }
    }

    handleValue = (e, feild) => {
        this.setState({
            [feild]: e.target.value
        })
    }

    render() {
        return (
            <Fragment>
                    <div className="row">
                        <div className="col-md-5 padding-30">
                    <div className="login-content">
                        <form>
                                <h4 className="title orgCol"> تسجيل الدخول </h4>
                                <br/><br/>
                                <h6 className="textRight">اسم المستخدم</h6>
                                <br />
                            <div className="input-div one">
                                <div className="i">
                                    <i className="fas fa-user"></i>
                                </div> 
                                <div className="div">
                                    <h5></h5> 
                                    <input type="text" className="input" value={this.state.userName} placeholder="إسم المستخدم" onChange={(e) => this.handleValue(e, "userName")} />
                                </div>
                            </div>
                                <h6 className="textRight">كلمه المرور</h6>
                            <div className="input-div pass">
                                <div className="i">
                                    <i className="fas fa-lock"></i>
                                </div>

                                <div className="div">
                                    <h5></h5>
                                    <input type="password" className="input" value={this.state.password} placeholder="كلمة المرور" onChange={(e) => this.handleValue(e, "password")} />
                                </div>
                            </div>
                                <br /><br />
                                {this.state.isLoading ?
                                    <Button variant="primary" disabled>
                                        <Spinner
                                            as="span"
                                            animation="grow"
                                            size="sm"
                                            role="status"
                                            aria-hidden="true"
                                        />
                                        تحميل
                                    </Button>
                                    : <input type="button" className="btnLogin" value="تسجيل دخول" onClick={() => this.handleLogin()} />}
<input type="button" className="btnLogin" value="تسجيل دخول للحسابات " onClick={() => this.handleLoginForSystem()} />
                                <br /><br />
                        </form>
                            </div>
                        </div>
                    <div className="col-md-7">
                        <img className="bk-login" src={bgLogin} />
                            </div>
                    </div>
            </Fragment>
        );
    }
}

const mapStateToProps = (state, ownProps) => ({
    token: state.reduces.token
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Login);
