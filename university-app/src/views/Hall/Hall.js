import React, { useState, useEffect, Fragment } from 'react';
import { Card, CardHeader, CardBody, CardTitle, Table, Row, Col, InputGroup, Input, InputGroupText} from "reactstrap";
import { Button, Modal, Container} from 'react-bootstrap';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import { useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBan, faPenToSquare, faPlus, faPlusCircle, faClose, faXmark, faUser} from "@fortawesome/free-solid-svg-icons";
//import AddHall from './AddHall';
import EditHall from './EditHall';
import ShtoHall from './ShtoHall'

const Hall = () => {
  const [halls, setHalls] = useState([]);
  const [isAddHallOpen, setIsAddHallOpen] = useState(false);
  const [isEditHallOpen, setIsEditHallOpen] = useState(false);
  const [hallId, setHallId] = useState(null);

  const [loactionId, setLocationId] = useState(null);

  const [search, setSearch] = useState ('');

  const [fshij, setFshij] = useState('');

  const [shto, setShto] = useState(false);
  const [refreshD, setRefreshD] = useState("");
  const handleShow = () => setShto(true);

  useEffect(() => {
    fetchHalls();
  }, []);

  const fetchHalls = async () => {
    try {
      const response = await axios.get('https://localhost:7028/api/Hall');
      setHalls(response.data);
    } catch (error) {
      console.error('Error fetching halls!', error);
    }
  };

  const handleAddHallToggle = () => setIsAddHallOpen(!isAddHallOpen);
  const handleEditHallToggle = (id) => {
    setHallId(id);
    setIsEditHallOpen(!isEditHallOpen);
  };

  const handleDelete = (locationId) => {
    setFshij(true);
    setLocationId(locationId);
  };

  const handleDeleteHall = async (hallId) => {
    console.log("Deleting location with ID:", hallId); 
    try {
      await axios.delete(`https://localhost:7028/api/Hall/${hallId}`).then(() => {
        setFshij(false);
        setHalls((prevHalls) => prevHalls.filter(h => h.hallId !== hallId));
        toast.success('Hall deleted succesfully!')
      })
    } catch (e) {
        toast.error('Failed to delete this hall.');
    }
  };

  const tableStyle = {
    overflowX: 'auto',
    display: 'block'
  };

  const minWidthStyle = {
    minWidth: '1500px' // Përshtati sipas nevojës për gjerësi të tabelës
  };


  return (
    <div className='content'>
        {fshij && (
            <Modal show={fshij} onHide={() => setFshij(false)}>
              <Modal.Header closeButton>
                <Modal.Title style={{ color: "red" }}>Delete Hall</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <h6>Are you sure you want to delete this Hall?</h6>
              </Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={() => setFshij(false)}>
                  Cancel
                </Button>
                <Button variant="danger" onClick={() => handleDeleteHall(hallId)}>
                  Delete Hall
                </Button>
              </Modal.Footer>
            </Modal>
        )}
      <Row>
<Col md="12">
  <Card>
    <CardHeader>
      <CardTitle tag="h4">Hall Table</CardTitle>
      <br/>
      <form>
        <InputGroup className="no-border">
          <Input onChange={(e)=> setSearch(e.target.value)} placeholder="Search..." />
          <InputGroupText>
            <i className="nc-icon nc-zoom-split" />
          </InputGroupText>
        </InputGroup>
      </form>
    </CardHeader>
    <CardBody>
    <Button onClick={handleShow} style={{marginBottom: "20px", marginTop: "20px"}}>Add Hall  <FontAwesomeIcon icon={faPlus} transform="grow-3" style={{ marginLeft: "8px" }}/></Button>
    <Container>
      <div style={tableStyle}>
      <Table style={minWidthStyle} responsive>
        <thead className="text-primary">
          <tr>
              <th>#</th>
              <th>Hall Code</th>
              <th>Type</th>
              <th>Capacity</th>
              <th>Location</th>
            </tr>
          </thead>
          <tbody>
              {
                  halls.filter((hall)=> {return search.toLowerCase() === ''? hall : hall.hallCode.toLowerCase().includes(search.toLowerCase())})
                  .map((hall, index)=>{
                      return (
                          <tr key={hall.hallID}>
                              <td>{index + 1}</td>
                              <td>{hall.hallCode}</td>
                              <td>{hall.type}</td>
                              <td>{hall.hallCapacity}</td>
                              <td>{hall.location ? `${hall.location.address} - ${hall.location.city}` : 'N/A'}</td>
                              {/*<td>{hall.location ? `${hall.location.address}, ${hall.location.city}` : 'N/A'}</td>*/}
                              <td>
                                  <button className="btn btn-primary"  onClick={() => handleEditHallToggle(hall.hallID)}><FontAwesomeIcon icon={faPenToSquare} /></button> &nbsp;
                                  <button className="btn btn-danger" onClick={()=> handleDelete(hall.hallID)}><FontAwesomeIcon icon={faBan} /></button>
                              </td>
                        </tr>
                      )
                  })
              }
          </tbody>
        </Table>
        </div>
        </Container>
        </CardBody>
  </Card>
</Col>        
</Row>
<Fragment>

      {/* Modals */}
      <EditHall isOpen={isEditHallOpen} toggle={handleEditHallToggle} hallId={hallId} fetchHalls={fetchHalls} />
      {/*<AddHall isOpen={isAddHallOpen} toggle={handleAddHallToggle} fetchHalls={fetchHalls} />*/}
      {shto && (
        <ShtoHall
          show={handleShow}
          hide={() => setShto(false)}
          //shfaqmesazhin={() => setShfaqMesazhin(true)}
          perditesoTeDhenat={() => setRefreshD(Date.now())}
          //setTipiMesazhit={setTipiMesazhit}
          //setPershkrimiMesazhit={setPershkrimiMesazhit}
        />
      )}
      {/*<EditHall isOpen={isEditHallOpen} toggle={handleEditHallToggle} hallId={hallId} fetchHalls={fetchHalls} />*/}
      </Fragment>
    </div>
  );
};

export default Hall;
