import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import ReactTable from '../renderData/renderData';
import Config from "../../Config/Config";
import toastr from 'toastr';
import '../../Design/CSS/custom.css';
import { Button } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';


class PurchaseOrder extends Component {

    constructor(props) {

        super(props);

        //let userType = JSON.parse(localStorage.getItem("userType"));


        //if (userType !== 2) {
        //    toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
        //    this.props.history.push("/DashBoard");
        //}
        // this is columns of Department
        this.cells = [
            //{
            //    Header: "",
            //    id: "checkbox",
            //    accessor: "",
            //    Cell: (rowInfo) => {
            //        return (
            //            <div>
            //                <OverlayTrigger
            //                    key={`topDelete-${rowInfo.original.id}`}
            //                    placement={'top'}
            //                    overlay={
            //                        <Tooltip id={`tooltip-top`}>
            //                            <strong>حذف</strong>.
            //                       </Tooltip>
            //                    }>
            //                    <img src={Delete} className="Delete"
            //                        onClick={() => this.viewConfimeRowDelete(rowInfo.original.id, rowInfo.original.customerId)}
            //                        style={{ width: "25px", cursor: 'pointer', marginRight: '15px' }} />
            //                </OverlayTrigger>
            //                <OverlayTrigger
            //                    key={`topEdit-${rowInfo.original.id}`}
            //                    placement={'top'}
            //                    overlay={
            //                        <Tooltip id={`tooltip-top`}>
            //                            <strong>تعديل</strong>.
            //                 </Tooltip>
            //                    }>
            //                    <img src={Edit} className="Edit"
            //                        onClick={() => this.props.history.push(`/PurchaseOrderAddEdit/${rowInfo.original.id}/true`)}
            //                        style={{ width: "25px", cursor: 'pointer' }} />
            //                </OverlayTrigger>
            //            </div>
            //        );
            //    },
            //    sortable: false,
            //    width: 100
            //},
            //{
            //    Header: <strong> رقم فاتورة المورد </strong>,
            //    accessor: 'numberOfInvoiceSupplier',
            //    width: 85,
            //    filterable: true,
            //},
            {
                Header: <strong> المورد </strong>,
                accessor: 'customerName',
                width: 190,
                filterable: true,
            }, {
                Header: <strong> عدد أصناف الفاتورة </strong>,
                accessor: 'itemCount',
                width: 80,
                filterable: true,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> التاريخ </strong>,
                accessor: 'date',
                width: 120,
            }, {
                Header: <strong> الأجمالى </strong>,
                accessor: 'totalInvoice',
                width: 100,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> المدفوع </strong>,
                accessor: 'payed', width: 100,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> المتبقى </strong>,
                accessor: 'amount', width: 100,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            },
            //{
            //    Header: <strong> التسعير </strong>,
            //    accessor: 'isPrice', width: 120,
            //},
            {
                Header: <strong> الملاحظات </strong>,
                accessor: 'description',
                width: 180,
            }
        ];

        this.cellsItems = [
            {
                Header: <strong> المنتح </strong>,
                accessor: 'productName',
                width: 150
            }, {
                Header: <strong> التخانة </strong>,
                accessor: 'size',
                width: 70,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> العرض </strong>,
                accessor: 'width',
                width: 70,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> الطول </strong>,
                accessor: 'hight',
                width: 70,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> الكمية </strong>,
                accessor: 'quantity',
                width: 70,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> سم </strong>,
                accessor: 'centi',
                width: 80,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> المتر </strong>,
                accessor: 'meter',
                width: 70,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> الكود </strong>,
                accessor: 'code',
                width: 85,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            }, {
                Header: <strong> سعر الشراء </strong>,
                accessor: 'priceSupplier',
                width: 80,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            },
            {
                Header: <strong> الأجمالى </strong>,
                accessor: 'totalPrice',
                width: 100,
                Cell: props => <span style={{ color: "red" }}>{props.value}</span>
            },
            {
                Header: <strong> النوع </strong>,
                accessor: 'typeText'
            }
        ];
        // initial value of state



        this.state = {
            show: false,
            textModal: "إضافة",
            objSupplier: {
                id: 0,
                name: '',
                address: '',
                phone: ''
            },
            selected: [],
            listItems: [],
            isLoading: false,
            showConfirme: false,
            type: "",
            totalSize1: 0,
            totalQty1: 0,
            totalSize2: 0,
            totalQty2: 0,
            totalQty3: 0,
            startDate: new Date(),
            finishDate: new Date(),
            listPurchaseOrder: [],
            objCustomer: {},
            customerId: 0
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        this.setState({
            listPurchaseOrder: nextState.listPurchaseOrder
        });
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        //this.props.actions.getAllPurchaseOrder();
    }

    // this function when add new data and view modal
    showModal() {
        this.props.history.push("/PurchaseOrderAddEdit/0");
    }

    // this function when get value from grid to edit feild
    viewDetails = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.className === "Edit") {
                    let items = this.state.listPurchaseOrder.find(x => x.id === rowInfo.original.id);

                    if (items.isPrice === "لم تسعر") {
                        this.props.history.push(`/PurchaseOrderAddEdit/${items.id}/false`);
                    }
                    //else {
                    //    this.props.history.push(`/PurchaseOrderAddEdit/${rowInfo.original.id}/true`);
                    //} 
                } else if (e.target.className != "Delete") {
                    let items = this.state.listPurchaseOrder.find(x => x.id === rowInfo.original.id);

                    if (items.isPrice === "لم تسعر") {
                        this.props.history.push(`/PurchaseOrderAddEdit/${items.id}/false`);
                    }
                    else {
                        let items = this.props.listPurchaseOrder.find(x => x.id === rowInfo.original.id).listPurchaseOrderDetails;

                        let totalSize1 = items.length > 0 ? items.filter(x => x.code == "" && x.type === true) : 0;
                        if (totalSize1.length > 0) {
                            totalSize1 = totalSize1.map(x => {
                                let centi = x.centi.includes(".") ? x.centi.split('.')[1].toString() : x.centi
                                return parseFloat(x.meter.toString() + "." + centi)
                            }).reduce((a, c) => { return a + c });
                        } else {
                            totalSize1 = 0;
                        }

                        let totalSize2 = items.length > 0 ? items.filter(x => x.code != "" && x.type === true) : 0;
                        if (totalSize2.length > 0) {
                            totalSize2 = totalSize2.map(x => {
                                let centi = x.centi.includes(".") ? x.centi.split('.')[1].toString() : x.centi
                                return parseFloat(x.meter.toString() + "." + centi)
                            }).reduce((a, c) => { return a + c });
                        } else {
                            totalSize2 = 0;
                        }


                        let totalQty1 = items.length > 0 ? items.filter(x => x.code == "" && x.type === true) : 0;
                        if (totalQty1.length > 0) {
                            totalQty1 = totalQty1.map(x => x.quantity).reduce((a, c) => { return a + c })
                        } else {
                            totalQty1 = 0;
                        }

                        let totalQty2 = items.length > 0 ? items.filter(x => x.code != "" && x.type === true) : 0;
                        if (totalQty2.length > 0) {
                            totalQty2 = totalQty2.map(x => x.quantity).reduce((a, c) => { return a + c });
                        } else {
                            totalQty2 = 0;
                        }

                        let totalQty3 = items.length > 0 ? items.filter(x => x.type === false) : 0;
                        if (totalQty3.length > 0) {
                            totalQty3 = totalQty3.map(x => x.quantity).reduce((a, c) => { return a + c })
                        } else {
                            totalQty3 = 0;
                        }

                        items.forEach(i => {
                            i.centi = i.centi.includes(".") ? i.centi.split('.')[1].toString() : i.centi;
                            i.totalPrice = i.type === true ? (i.priceSupplier * (i.meter + "." + parseFloat(i.centi))).toFixed(0) : (i.priceSupplier * i.quantity).toFixed(0);
                        });

                        this.setState({
                            totalSize1,
                            totalSize2,
                            totalQty1,
                            totalQty2,
                            totalQty3,
                            show: true,
                            listItems: items,
                            objCustomer: rowInfo.original
                        });
                    }
                }
            }
        };
    };

    // this function when close modal
    handleClose() {
        this.setState({
            showConfirme: false,
            show: false
        });
    }

    handleSearch = () => {

        var date = new Date(this.state.startDate);
        var date2 = new Date(this.state.finishDate);

        var dateString = new Date(date.getTime() - (date.getTimezoneOffset() * 60000)).getTime()//.toISOString()//.split("T")[0];
        var dateString2 = new Date(date2.getTime() - (date2.getTimezoneOffset() * 60000)).getTime()//.toISOString()//.split("T")[0];

        let result = this.props.listPurchaseOrder.filter(d => {
            var time = new Date(d.date).getTime();
            return (dateString <= time && time <= dateString2);
        });

        this.setState({
            listPurchaseOrder: result
        });
    }

    handleResetSearch = () => {
        this.setState({
            listPurchaseOrder: this.props.listPurchaseOrder
        });
    }

    // this function when Delete one item
    viewConfimeRowDelete = (id, customerId) => {

        let selectedRows = this.state.selected;

        if (selectedRows.length > 0) {
            selectedRows = []
        }

        selectedRows.push(id);

        this.setState({
            showConfirme: true,
            selected: selectedRows,
            type: "Row"
        });
    }

    // this function when submit Delete item
    handleDelete = () => {

        if (this.state.customerId > 0) {
            this.props.actions.deletePurchaseOrderByAdmin(this.state.selected[0]);

        } else {
            this.props.actions.deletePurchaseOrderWithoutSupplier(this.state.selected[0]);
        }

        this.setState({
            show: false,
            showConfirme: false,
            selected: []
        });
    }


    render() {
        return (
            <Fragment>
                <div className="main_content_container">
                    <div className="page_content">
                        <br />
                        <br />
                        <h1 className="heading_title">عرض كل فواتير المشتريات</h1>
                        {/* Button of Add new Document and delete Row in Grid */}
                        <br />
                        <br />
                        <div className="page-title-actions">
                            <Button size="lg" style={{ width: '80px', height: '35px' }} onClick={this.showModal.bind(this)}>إضافة</Button>
                        </div>
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            data={this.state.listPurchaseOrder}
                            columns={this.cells}
                        //getTrProps={this.viewDetails}
                        //defaultPageSize={200}
                        />
                    </div>
                    <Confirme show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleDelete} />
                </div>
            </Fragment>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    listPurchaseOrder: state.reduces.listPurchaseOrder
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(PurchaseOrder);
