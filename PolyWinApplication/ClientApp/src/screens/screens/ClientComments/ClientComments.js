import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import UploadFiles from "../../components/FileUpload/UploadFiles";
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    Comment: Yup.string().required("برجاء إدخال وصف التعليق").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class ClientComments extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/System/DashBoard");
        }

        // this is columns of Department
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <div>
                            <Form.Check
                                checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
                                onChange={() => this.toggleRow(rowInfo.original.id)} />
                            <OverlayTrigger
                                key={`topimg-${rowInfo.original.comment}`}
                                placement={'top'}
                                overlay={
                                    <Tooltip id={`tooltip-top`}>
                                        <strong>الفيديو</strong>
                                    </Tooltip>
                                }>
                                <Button variant="primary" onClick={() =>
                                    this.setState({
                                        showVideo: true,
                                        vidPath: rowInfo.original.vidPath
                                    })
                                } className="EditCredit" style={{ cursor: 'pointer' }}>عرض الفيديو</Button>
                            </OverlayTrigger>

                            <OverlayTrigger
                                key={`topimg-${rowInfo.original.id}`}
                                placement={'top'}
                                overlay={
                                    <Tooltip id={`tooltip-top`}>
                                        <strong>الصورة</strong>
                                    </Tooltip>
                                }>
                                <Button variant="danger" onClick={() =>
                                    this.setState({
                                        showImage: true,
                                        imgPath: rowInfo.original.imgPath
                                    })
                                } className="EditCredit" style={{ cursor: 'pointer' }}>عرض الصورة</Button>
                            </OverlayTrigger>
                        </div>
                    );
                },
                sortable: false,
                width: 250
            },
            {
                Header: <strong> التعليق </strong>,
                accessor: 'comment',
                width: 400,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            Comment: "",
            id: 0,
            imgPath: "",
            show: false,
            showImage: false,
            showVideo: false
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListClientComm && nextState.ListClientComm.length > 0) {

            this.setState({
                isLoading: false,
                show: false
            });
        } else {
            this.setState({
                isLoading: false,
                show: false
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.GetAllClientOpinions();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            Comment: "",
            imgPath: "",
            vidPath: "",
            Img: "",
            Vid:"",
            id: 0
        });
    }

    showDeleteModal() {
        this.setState({
            showConfirme: true
        });
    }


    // this function when close modal
    handleClose() {
        this.setState({
            show: false,
            showImage: false,
            showVideo: false,
            showConfirme: false
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.DeleteClientsOpinion(this.state.selected);
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

    editClientComm = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {

                    this.setState({
                        Comment: rowInfo.original.Comment,
                        id: rowInfo.original.id,
                        Vid: "",
                        Img: "",
                        show: true
                    });
                }
            }
        };
    };

    getVidInfo = (files) => {
        this.setState({
            Vid: files
        });
    }

    getImgInfo = (files) => {
        this.setState({
            Img: files
        });
    }

    addEditClientComm = (value) => {
        this.setState({
            isLoading: true
        });
        if (value.id > 0) {
            const body = new FormData();

            body.append('Vid', this.state.Vid);
            body.append('Comment', value.Comment);
            body.append('Img', this.state.Img);
            body.append('Id', value.id);

            this.props.actions.AddEditClientsOpinion(body);
            this.handleClose();
            this.props.actions.GetAllClientOpinions();
        } else {
            if (this.state.Vid !== "" || this.state.Img !== "") {
                const body = new FormData();

                body.append('Vid', this.state.Vid);
                body.append('Comment', value.Comment);
                body.append('Img', this.state.Img);
                body.append('Id', value.id);

                this.props.actions.AddEditClientsOpinion(body);
                this.handleClose();
                this.props.actions.GetAllClientOpinions();
            } else {
                toastr.success("برجاء اختيار صورة ");
                this.setState({
                    isLoading: false
                });
            }
        }
    }

    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">آراء العملاء</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModal.bind(this)}>إضافة </Button>
                            {this.state.selected.length > 0 ?
                                <Button size="lg" onClick={this.showDeleteModal.bind(this)}>حذف</Button>
                                : null}
                        </div>
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editClientComm}
                            data={this.props.ListClientComm}
                            columns={this.cells}
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        إضافة أو تعديل تعليق
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} onSubmit={(values) => { this.addEditClientComm(values) }}
                            initialValues={{
                                id: this.state.id,
                                Comment: this.state.Comment,
                                imgPath: this.state.imgPath
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="name">
                                        <Form.Label>التعليق</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="التعليق"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="Comment"
                                            autoComplete="off"
                                            value={values.Comment}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.Comment}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.Comment}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Label> الصوره</Form.Label>
                                    <UploadFiles acceptFile="image/*" getfileInfo={this.getImgInfo} />

                                    <Form.Label>الفيديو</Form.Label>
                                    <UploadFiles acceptFile="video/*" getfileInfo={this.getVidInfo} />

                                    <div style={{ direction: "ltr" }}>
                                        <Button size="lg" onClick={this.handleClose.bind(this)} style={{ marginRight: '10px' }}>
                                            غلق
                                        </Button>
                                        {this.state.isLoading ? <Button size="lg" disabled  >
                                            <Spinner
                                                as="span"
                                                animation="grow"
                                                size="sm"
                                                role="status"
                                                aria-hidden="true"
                                            />
                                            تحميل
                                        </Button> :
                                            <Button size="lg" variant="success" type="submit">
                                                حفظ
                                            </Button>}
                                    </div>
                                </Form>
                            )}
                        </Formik>
                    </Modal.Body>
                </Modal>
                <Modal show={this.state.showImage} onHide={this.handleClose.bind(this)}>
                    <Modal.Body className="modal-header">
                        {this.state.imgPath !== "" || this.state.imgPath !== null ?
                            <img src={this.state.imgPath} style={{ width: '100%' }} />
                            : <div>
                                <span>
                                    لا توجد صورة
                                </span>
                            </div>
                        }
                    </Modal.Body>
                </Modal>
                <Modal show={this.state.showVideo} onHide={this.handleClose.bind(this)}>
                    <Modal.Body className="modal-header">
                        {
                            (this.state.vidPath !== "" || this.state.vidPath !== null)
                                ? (<video style={{ width: '100%' }} controls><source src={this.state.vidPath} type="video/mp4"></source></video>)
                            : (<div><span> لا يوجد فيديو </span></div>)
                        }
                    </Modal.Body>
                </Modal>

                {this.state.showConfirme ? <Confirme text="هل تريد الحذف ?" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListClientComm: state.reduces.ListClientComm
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ClientComments);