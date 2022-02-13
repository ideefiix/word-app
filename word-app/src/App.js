import './App.css';
import { ListGroup, Row, Container, Button } from 'react-bootstrap';
import ListPickerPage from './pages/ListPickerPage'
import ListSelectedPage from './pages/ListSelectedPage';
import { useState } from 'react';

function App() {

  const [ListIsSelected, setListIsSelected] = useState(false)
  const [wordlist, setWordlist] = useState({})

  return (
    <div className="App">
      <div className='primary-coloring justify-content-center d-flex mb-2'>
        <p className=''><b>Filles minnesord-hjälpare 1.0</b></p>
      </div>

      <Container className='app-body'>
        {ListIsSelected ? <ListSelectedPage wordlist={wordlist} setWordlist={setWordlist}/> : <ListPickerPage setListIsSelected={setListIsSelected} setWordlist={setWordlist} />}

      </Container>
    </div>
  );
}

export default App;
