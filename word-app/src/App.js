import './App.css';
import { ListGroup, Row, Container, Button, Col } from 'react-bootstrap';
import ListPickerPage from './pages/ListPickerPage'
import ListSelectedPage from './pages/ListSelectedPage';
import { useState } from 'react';

function App() {

  const [selectedList, setSelectedList] = useState(null)

  return (
    <div className="App">
      <Row className='primary-coloring mb-2'>
        {selectedList ?
          <>
            <Col xs={1}></Col>
            <Col xs={1}><p className='center' onClick={() => setSelectedList(null)}>{"<"}</p></Col>
          </>
          :
          <Col xs={2}></Col>}

        <Col><p className='justify-content-center'><b>Filles minnesord-hjälpare 1.0</b></p></Col>
      </Row>

      <Container className='app-body'>
        {selectedList ? <ListSelectedPage selectedList={selectedList} setSelectedList={setSelectedList} /> : <ListPickerPage setSelectedList={setSelectedList} />}

      </Container>
    </div>
  );
}

export default App;
