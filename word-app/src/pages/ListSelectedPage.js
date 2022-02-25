import React from 'react'
import '../App.css';
import { ListGroup, Row, Container, Button, Table } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import {db_addWordToList, db_fetchWordsInList} from '../Communicator'
import axios from 'axios';

const ListSelectedPage = (props) => {
  const [words, setWords] = useState([])
  useEffect(() => {
    fetchWords()
  }, [])
  
  async function fetchWords(){
    console.log(props.selectedList);
   let res = await db_fetchWordsInList(props.selectedList.id);
    setWords(res.data)
  }

  async function addWord() {
    let newWord = prompt("Skriv in det nya ENGELSKA ordet")
    if (newWord == null || newWord == "") return -1

    await db_addWordToList(props.selectedList.id, newWord)
    fetchWords()
   
  }
  return (
    <>
      <h3>{props.selectedList.name}</h3>
      <Table striped hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Engelska</th>
            <th>Svenska</th>
          </tr>
        </thead>
        <tbody>
          {words.map(word => (
            <tr key={word.sv}>
              <td>{words.indexOf(word) + 1}</td>
              <td>{word.en}</td>
              <td>{word.sv}</td>
            </tr>
          ))}
        </tbody>

      </Table>
      <Button onClick={() => addWord()}>Lägg till ord</Button>
    </>
  )
}

export default ListSelectedPage