import React, { Component } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import Select from "react-select";
import { Button, Form, Modal, Spinner, Container } from 'react-bootstrap';
import toastr from 'toastr';
import RenderData from '../renderData/renderData';
import axios from "axios";
import { Formik } from "formik";
import * as Yup from "yup";
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    categoryName: Yup.string().required("برجاء كتابة القسم").max(100, "الحد الاقصى 100 حرف")
});

class Products extends Component {

    constructor(props) {
        super(props);

        // this is columns of Jobs
        this.cells = [
            //{
            //    Header: "",
            //    id: "checkbox",
            //    accessor: "",
            //    Cell: (rowInfo) => {
            //        return (
            //            <Form.Check
            //                checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
            //                onChange={() => this.toggleRow(rowInfo.original.id)} />
            //        );
            //    },
            //    sortable: false,
            //    width: 45
            //},
            {
                Header: <strong>القسم</strong>,
                accessor: 'categoryName',
                filterable: true
            },
            {
                Header: <strong>كود المنتج</strong>,
                accessor: 'productCode',
                filterable: true
            }, {
                Header: <strong>اسم المنتج</strong>,
                accessor: 'name',
                filterable: true
            },
            {
                Header: <strong>السعر بالوحدة</strong>,
                accessor: 'pricePerOne',
                filterable: true
            },
            {
                Header: <strong>السعر بالمتر</strong>,
                accessor: 'pricePerMeter',
                filterable: true
            },
            {
                Header: <strong>وحدة القياس</strong>,
                accessor: 'measruingUnit',
                filterable: true
            },
            {
                Header: <strong>اجمالى الوحدة</strong>,
                accessor: 'totalQuota',
                filterable: true
            }
        ];

        this.state = {
            objProduct: {
                id: 0,
                categoryId: '',
                categoryName: '',
                name: '',
                Photo: null,
                totalQuota: 1,
                productCode: '',
                measruingUnit: '',
                pricePerMeter: 0,
                pricePerOne: 0
            },
            listCategory: [],
            listTypeOfProduct: [
                { label: "الكرتونه", value: "الكرتونه" },
                { label: "العدد", value: "العدد" },
                { label: "الوزن", value: "الوزن" },
                { label: "الطول", value: "الطول" },
                { label: "اللفة", value: "اللفة" }],
            isOpen: false,
            isEdit: false,
            isloading: false,
            file: null,
            label: "برجاء اختيار الصورة",
            categoryId: '',
            measruingUnitId: ''
        }
    }

    componentDidMount() {
        //this.props.actions.getAllCategory();
        //this.props.actions.getAllProducts();
    }

    toggleRow(id) {
        const isAdd = this.state.selected.indexOf(id);

        let newSelected = this.state.selected;

        if (isAdd > -1) {
            newSelected.splice(isAdd, 1);
        } else {
            if (newSelected.length > 0) {
                newSelected = [];
            }
            newSelected.push(id);
        }

        this.setState({
            selected: newSelected
        });
    }

    handleChange(e, type) {
        let originalCategory = this.state.objCategory;
        originalCategory[type] = e.target.value;

        this.setState({
            objCategory: originalCategory
        });
    }

    saveCategory = () => {
        this.setState({
            isloading: true
        });

        var formData = new FormData();
        formData.append('file', this.state.objCategory.file);
        formData.append('categoryName', this.state.objCategory.categoryName);
        formData.append('id', this.state.objCategory.id);

        axios.post('api/MMD/AddEditCategory', formData).then(result => {

            let originalDoc = this.state.objCategory;
            let listCat = this.state.listCategory;

            originalDoc.id = result.data.id;
            originalDoc.categoryName = result.data.categoryName;

            toastr.success("Success");

            if (this.state.isEdit === true) {

                let indexx = listCat.findIndex(x => x.id === result.data.id);

                listCat.splice(indexx, 1);

                listCat.push(originalDoc);
            } else {
                let listCat = this.state.listCategory;

                listCat.push(originalDoc);
            }

            originalDoc = {
                id: 0,
                categoryName: '',
                file: null
            }

            this.setState({
                objCategory: originalDoc,
                listCategory: listCat,
                isOpen: false,
                isEdit: false,
                isloading: false,
                file: null
            });
        });
    }

    // this function when get value from grid to edit feild
    editCategory = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox") {
                    let originalDept = this.state.objCategory;

                    originalDept.id = rowInfo.original.id;
                    originalDept.categoryName = rowInfo.original.categoryName;

                    this.setState({
                        objCategory: originalDept,
                        isOpen: true,
                        isEdit: true,
                        file: rowInfo.original.imgURL
                    });
                }
            }
        };
    };

    cancelPage = () => {
        this.props.history.push("/");
    }

    viewModal = () => {
        let obj = this.state.objCategory;

        obj = {
            id: 0,
            categoryName: '',
            file: null
        }
        this.setState({
            objCategory: obj,
            isOpen: !this.state.isOpen,
            isEdit: false,
            isloading: false
        });
    }

    handleFileUpload(e) {
        if (e.target.files[0] !== undefined) {

            let originalObj = this.state.objProduct;

            originalObj.Photo = e.target.files[0];

            this.setState({
                label: e.target.files[0].name,
                file: URL.createObjectURL(e.target.files[0]),
                objProduct: originalObj
            });
        }
    }

    viewConfimeDelete() {

        this.setState({
            isloading: true
        });

        axios.get('api/MMD/DeleteCategory?id=' + this.state.selected[0]).then(result => {
            let originalData = this.state.listCategory;
            let index = originalData.findIndex(x => x.id == this.state.selected[0]);

            originalData.splice(index, 1);

            this.setState({
                listCategory: originalData,
                isloading: false
            });
            toastr.success("تم الحذف بنجاح");
        });
    }


    handleChange(value, name) {
        this.setState({
            [name]: value
        });
    }

    handleChangeInput(e, name) {

        var obj = this.state.objProduct;
        obj[name] = e.target.value;

        this.setState({
            objProduct: obj
        });
    }

    saveProuct = (values) => {

        console.log(values);
        this.setState({
            isloading: true
        });

        var formData = new FormData();
        formData.append('Photo', this.state.objProduct.Photo);
        formData.append('name', this.state.objProduct.name);
        formData.append('id', this.state.objProduct.id);
        formData.append('totalQuota', this.state.objProduct.totalQuota);
        formData.append('productCode', this.state.objProduct.productCode);
        formData.append('pricePerMeter', this.state.objProduct.pricePerMeter);
        formData.append('pricePerOne', this.state.objProduct.pricePerOne);
        formData.append('categoryId', this.state.categoryId.value);
        formData.append('measruingUnit', this.state.measruingUnitId.value);

        this.props.actions.saveProuct(formData);

        this.setState({
            isloading: true,
            isOpen: false
        });
    }


    render() {
        return (
            <Container>
                <Button style={{ width: '80px', height: '35px' }} onClick={this.viewModal}>إضافة</Button>

                <div className="mt-3">
                    {this.state.isloading ? null :
                        <RenderData
                            columns={this.cells}
                            data={this.props.listProducts}
                            getTrProps={this.editCategory}
                        />
                    }
                </div>
                <Modal show={this.state.isOpen} onHide={this.viewModal.bind(this)}>
                    <Modal.Header closeButton>
                        <Modal.Title> اضافة منتج جديد</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Formik validationSchema={schema} initialValues={{
                            id: this.state.objProduct.id,
                            name: this.state.objProduct.name,
                            totalQuota: this.state.objProduct.totalQuota,
                            productCode: this.state.objProduct.productCode,
                            pricePerMeter: this.state.objProduct.pricePerMeter,
                            pricePerOne: this.state.objProduct.pricePerOne
                        }}>
                            {({ handleSubmit, handleChange, handleBlur, values, touched, setFieldTouched, errors, setFieldValue }) => (
                                <Form noValidate onSubmit={handleSubmit}>
                                    <Form.Group controlId="jobs">
                                        <Form.Label>القسم</Form.Label>
                                        <Select
                                            name="category"
                                            id="category"
                                            value={this.state.categoryId}
                                            onChange={(opt) => { this.handleChange(opt, 'categoryId') }}
                                            options={this.props.listCategory}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="productCode">
                                        <Form.Label>كود الصنف</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="كود الصنف"
                                            onChange={(opt) => { this.handleChangeInput(opt, 'productCode') }}
                                            aria-describedby="inputGroupPrepend"
                                            name="productCode"
                                            value={this.state.objProduct.productCode}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="name">
                                        <Form.Label>اسم المنتج</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="اسم المنتج"
                                            onChange={(opt) => { this.handleChangeInput(opt, 'name') }}
                                            aria-describedby="inputGroupPrepend"
                                            name="name"
                                            value={this.state.objProduct.name}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="name">
                                        <Form.Label>اجمالى الوحدة</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="اجمالى الوحدة"
                                            onChange={(opt) => { this.handleChangeInput(opt, 'totalQuota') }}
                                            aria-describedby="inputGroupPrepend"
                                            name="name"
                                            value={this.state.objProduct.totalQuota}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="pricePerOne" >
                                        <Form.Label>السعر بالوحدة</Form.Label>
                                        <Form.Control type="number"
                                            style={{ height: "50px" }}
                                            placeholder="السعر بالوحدة"
                                            onChange={(opt) => { this.handleChangeInput(opt, 'pricePerOne') }}
                                            aria-describedby="inputGroupPrepend"
                                            name="pricePerOne"
                                            value={this.state.objProduct.pricePerOne}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="pricePerMeter" >
                                        <Form.Label>السعر بالمتر</Form.Label>
                                        <Form.Control type="number"
                                            style={{ height: "50px" }}
                                            placeholder="السعر بالمتر"
                                            onChange={(opt) => { this.handleChangeInput(opt, 'pricePerMeter') }}
                                            aria-describedby="inputGroupPrepend"
                                            name="pricePerMeter"
                                            value={this.state.objProduct.pricePerMeter}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="jobs">
                                        <Form.Label>نوع الوحدة</Form.Label>
                                        <Select
                                            name="measruingUnit"
                                            id="measruingUnit"
                                            value={this.state.measruingUnitId}
                                            onChange={(opt) => { this.handleChange(opt, 'measruingUnitId') }}
                                            options={this.state.listTypeOfProduct}
                                        />
                                    </Form.Group>
                                    <div className="form-group row">
                                        <label className="col-sm-2 col-form-label"></label>
                                        <div className="col-sm-10">
                                            <div className="custom-file">
                                                <input className="custom-file-input form-control" accept="image/*" type="file" onChange={(e) => this.handleFileUpload(e)} />
                                                <label className="custom-file-label">{this.state.label}</label>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <Button onClick={this.viewModal.bind(this)} style={{ width: '80px', height: '35px', marginRight: '10px' }}>
                                        غلق
                                            </Button>
                                    {this.state.isLoading ? <Button disabled style={{ width: '100px', height: '35px' }}>
                                        <Spinner
                                            as="span"
                                            animation="grow"
                                            size="sm"
                                            role="status"
                                            aria-hidden="true"
                                        />
                                              تحميل
                                            </Button> :
                                        <Button type="submit" style={{ width: '80px', height: '35px' }} onClick={this.saveProuct}>
                                            حفظ
                                                </Button>}
                                </Form>
                            )}
                        </Formik>
                    </Modal.Body>
                </Modal>
            </Container>
        );
    }
}



const mapStateToProps = (state, ownProps) => ({
    listCategory: state.reduces.listCategory,
    listProducts: state.reduces.listProducts
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Products);