import React from 'react'
import '../App.css';
import { ListGroup, Row, Container, Button } from 'react-bootstrap';
import { useState, useEffect } from 'react';

const ListPickerPage = (props) => {
  const [list, setList] = useState([])

  useEffect(() => {
    fetchLists()
  }, [])

  function createList() {
    let listName = prompt("Ge listan ett namn")
    if (listName == null || listName == "") return -1

    let createdAt = Date.now()
    let list = {
      name: listName,
      timeCreated: createdAt,
      words:[]
    }
    setList(prevList => ([...prevList, list]))
  }
  function fetchLists() {
    let arr = [
      { name: "Lista 3", timeCreated: Date.now() - 30, words:[{sv:"test",en:"test"}] },
      { name: "Lista 4", timeCreated: Date.now() - 20, words:[{sv:"test",en:"test"}] },
      { name: "Lista 2", timeCreated: Date.now() - 40, words:[{sv:"test",en:"test"}] },
      { name: "Lista 1", timeCreated: Date.now() - 50, words:[{sv:"test",en:"test"},{sv:"bajs",en:"poop"}] }
    ]
    //Lists is ordered by age 
    arr.sort((a, b) => a.timeCreated - b.timeCreated)
    setList(arr)
  }
  function selectList(list) {
    props.setWordlist(list)
    props.setListIsSelected(true)
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