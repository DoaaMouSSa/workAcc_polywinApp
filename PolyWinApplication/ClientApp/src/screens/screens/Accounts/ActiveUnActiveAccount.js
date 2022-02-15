import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Button } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import '../../Design/CSS/custom.css';



class ActiveUnActiveAccount extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }

        // this is columns of Department
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <Form.Check
                            checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
                            onChange={() => this.toggleRow(rowInfo.original.id)} />
                    );
                },
                sortable: false,
                width: 45
            },
            {
                Header: <strong> الأسم </strong>,
                accessor: 'name',
                width: 200,
                filterable: true,
            },
            {
                Header: <strong> إسم الحساب </strong>,
                accessor: 'username',
                width: 150,
                filterable: true,
            }, {
                Header: <strong>الرقم السرى</strong>,
                accessor: 'password',
                width: 150,
                filterable: true,
            },
       
            {
                Header: <strong> رقم الهاتف </strong>,
                accessor: 'phone',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong>النوع</strong>,
                accessor: 'userType',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong>الحالة</strong>,
                accessor: 'activeType',
                width: 150,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            _showConfirme: false
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListAccountsActiveNotActive && nextState.ListAccountsActiveNotActive.length > 0) {

            this.setState({
                isLoading: false,
                showInstallment: false,
                showConfirme: false,
                _showConfirme: false
            });
        } else {
            this.setState({
                isLoading: false,
                showInstallment: false,
                showConfirme: false,
                _showConfirme: false
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllAccountsActiveNotActive();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            showConfirme: true
        });
    }

    // this function when close modal
    handleClose() {
        this.setState({
            showConfirme: false
        });
    }


    // this function when add new data and view modal
    _showModal() {
        this.setState({
            _showConfirme: true
        });
    }

    // this function when close modal
    _handleClose() {
        this.setState({
            _showConfirme: false
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.activeNotActiveAccounts(this.state.selected);
    }

    // this function when submit Delete item
    _handleConfirm = () => {
        this.setState({
            _showConfirme: false,
            selected: []
        });

        this.props.actions.resetPassword(this.state.selected);
    }

    // this function when leave from page
    componentWillUnmont() {
        this.setState({
            show: false,
            isLoading: false,
            showConfirme: false
        });
    }


    toggleRow(id) {
        const isAdd = this.state.selected.indexOf(id);

        let newSelected = this.state.selected;

        if (isAdd > -1) {
            newSelected.splice(isAdd, 1);
        } else {

            newSelected.push(id);
        }

        this.setState({
            selected: newSelected
        });
    }

    render() {

        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left"> إيقاف / تفعيل الحساب</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            {this.state.selected.length > 0 ?
                                <div>
                                    <Button size="lg" onClick={this.showModal.bind(this)}>تفعيل</Button>
                                    <Button size="lg" onClick={this._showModal.bind(this)} style={{ marginRight: "20px" }}>إعادة تعيين كلمة المرور</Button>
                                </div>
                                : null}
                        </div>
                        <br />
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left"> كلمة المرور الجديدة : 0123456789</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            data={this.props.ListAccountsActiveNotActive}
                            columns={this.cells}
                        />
                    </div>
                </div>
                {this.state.showConfirme ? <Confirme text="هل انت متاكد تفعيل / إلغاء تفعيل الحساب ؟؟" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
                {this.state._showConfirme ? <Confirme text="هل انت متاكد من إعادة تعيين كلمة المرور ؟؟" show={this.state._showConfirme} handleClose={this._handleClose.bind(this)} handleDelete={this._handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListAccountsActiveNotActive: state.reduces.ListAccountsActiveNotActive
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ActiveUnActiveAccount);