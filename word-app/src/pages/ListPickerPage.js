import React from 'react'
import '../App.css';
import { ListGroup, Row, Container, Button } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import {db_fetchAllLists, db_createList} from '../Communicator'

const ListPickerPage = (props) => {
  // A list of wordLists
  const [list, setList] = useState([])

  useEffect(() => {
    fetchLists()
  }, [])

  async function createList() {
    let listName = prompt("Ge listan ett namn")
    if (listName == null || listName == "") return -1

    await db_createList(listName);
    await fetchLists();
  }
  
  async function fetchLists() {
    let li = await db_fetchAllLists()
    setList(li.data)
  }

  function selectList(list) {
    props.setSelectedList(list)
  }

  return (
    <>
      <Row>
        <h3>Dina listor</h3>
      </Row>
      <Row>
        <ListGroup variant="flush">
          {list.map(listItem => (
            <ListGroup.Item action key={listItem.name} onClick={() => selectList(listItem)}>{listItem.name}</ListGroup.Item>
          ))}
        </ListGroup>
      </Row>
      <Row>
        <Button className='test' onClick={() => createList()}>Lägg till lista</Button>
      </Row>
    </>
  )
}

export default ListPickerPage