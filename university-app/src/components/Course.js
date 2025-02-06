import React, {useState, useEffect, Fragment} from 'react';
import { Card, CardHeader, CardBody, CardTitle, Table, Row, Col} from "reactstrap";
import {Button, Modal, Container} from 'react-bootstrap';
import { Link } from 'react-router-dom';
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'

const Course =() => {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    

    const[name, setName] = useState('')
    const[code, setCode] = useState('')
    const[credits, setCredits] = useState('')
    const[category, setCategory] = useState('')

    const[editCourseId, setEditCourseId] = useState('');
    const[editName, setEditName] = useState('')
    const[editCode, setEditCode] = useState('')
    const[editCredits, setEditCredits] = useState('')
    const[editCategory, setEditCategory] = useState('')


    const[courses, setCourses] = useState([]);
    const [refreshD, setRefreshD] = useState("");
    const [editData, setEditData] = useState({
        courseId: '',
        name: '',
        code: '',
        credits: '',
        category: ''
    });

    /*const getData = () => {
        axios.get('https://localhost:7028/api/Course').then((result) =>{
            setCourses(result.courses)
        })
        .catch((error)=>{
            console.log(error)
        })
    }

    useEffect(()=> {
        getData();
    },[])*/

    useEffect(() => {
        const getCourses = async () => {
            try {
                const courses = await axios.get(
                    "https://localhost:7028/api/Course"
                );
                setCourses(courses.data);
            }
            catch (err) {
                console.log(err);
            }
        };
      
        getCourses();
      }, [refreshD]);

      
  

    const handleEdit =(courseId) => {
        handleShow();
        axios.get('https://localhost:7028/api/Course/${courseId}').then((result)=>{
            setEditName(result.data.name);
            setEditCode(result.data.code);
            setEditCredits(result.data.credits);
            setEditCategory(result.data.category);
            setEditCourseId(courseId);
        })
        .catch((error)=>{
            console.log(error);
        })
    }

    const handleDelete =(courseId) => {
        if(window.confirm("Are you sure you want to delete this course ?")) {
            axios.delete('https://localhost:7028/api/Course/${courseId}').then((result)=>{
                if(result.status === 200) {
                    toast.success('Course has been deleted');
                    setRefreshD();
                }
            })
            .catch((error)=>{
                toast.error(error);
            })
        }
    }

    const handleUpdate =()=> {
        const url = 'https://localhost:7028/api/Course/${editCourseId}';
        const data = {
            "courseId": editCourseId,
            "name": editName,
            "code": editCode,
            "credits": editCredits,
            "category": editCategory,
        }

        axios.put(url, data).then((result) => {
            handleClose();
            setRefreshD();
            clear();
            toast.success('Course has been updated !');
        }).catch((error)=>{
            toast.error(error);
        })
    }

    /*const handleSave =() => {
        const url = 'http://localhost:7028/api/Course';
        const data = {
            "name": name,
            "semester": semester,
            "ects": ects
        }

        axios.post(url, data).then((result) => {
            getData();
            clear();
            toast.success('Course has been added !');
        }).catch((error)=>{
            toast.error(error);
        })
    }*/

    const clear = () => {
        setName('');
        setCode('');
        setCredits('');
        setCategory('');
        setEditName('');
        setEditCode('');
        setEditCredits('');
        setEditCategory('');
        setEditCourseId('');
    }

    return (
        <>
      <div className="content">
        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Course Table</CardTitle>
              </CardHeader>
              <CardBody>
                <Table responsive>
                  <thead className="text-primary">
                    <tr>
                        <th>#</th>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Code</th>
                        <th>ECTS</th>
                        <th>Category</th>
                      </tr>
                    </thead>
                    <tbody>
                        {
                           courses.map((course, index)=>{
                                return (
                                    <tr key={course}>
                                        <td>{index + 1}</td>
                                        <td>{course.courseId}</td>
                                        <td>{course.name}</td>
                                        <td>{course.code}</td>
                                        <td>{course.credits}</td>
                                        <td>{course.category}</td>
                                        <td>
                                            <button className="btn btn-primary" onClick={()=> handleEdit(course.courseId)}>Edit</button> &nbsp;
                                            <button className="btn btn-danger" onClick={()=> handleDelete(course.courseId)}>Delete</button>
                                        </td>
                                  </tr>
                                )
                            })
                        }
                    </tbody>
                  </Table>

                  <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                            <Modal.Title>Modify / Update Course</Modal.Title>
                      </Modal.Header>
                      <Modal.Body>
                        <Col>
                            <Col>
                            <input type="text" className="form-control" placeholder="Enter Name"
                            value= {editName} onChange={(e)=> setEditName(e.target.value)} />
                            </Col>
                            <br/>
                            <Col>
                            <input type="text" className="form-control" placeholder="Enter Code"
                            value= {editCode} onChange={(e)=> setEditCode(e.target.value)} />
                            </Col>
                            <br/>
                            <Col>
                            <input type="text" className="form-control" placeholder="Enter Ects"
                            value= {editCredits} onChange={(e)=> setEditCredits(e.target.value)} />
                            </Col>
                            <Col>
                            <input type="text" className="form-control" placeholder="Enter Category"
                            value= {editCategory} onChange={(e)=> setEditCategory(e.target.value)} />
                            </Col>
                            <br/>
                            
                        </Col>
                      </Modal.Body>
                      <Modal.Footer>
                            <Button variant="secondary" onClick={handleClose}>
                              Close
                        </Button>
                        <Button variant="primary" onClick={handleUpdate}>
                              Save Changes
                        </Button>
                      </Modal.Footer>
                    </Modal>
              </CardBody>
            </Card>
          </Col>
          </Row>

            
        </div>
        </>
    )
}

export default Course;