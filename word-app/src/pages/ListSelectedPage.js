import React from 'react'
import '../App.css';
import { ListGroup, Row, Container, Button, Table } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import axios from 'axios';

const ListSelectedPage = (props) => {

  function addWord() {
    let newWord = prompt("Skriv in det nya ENGELSKA ordet")
    if (newWord == null || newWord == "") return -1

    //API request
    var axios = require("axios").default;
    var options = {
      method: 'GET',
      url: 'https://just-translated.p.rapidapi.com/',
      params: {lang: 'sv', text: newWord},
      headers: {
        'x-rapidapi-host': 'just-translated.p.rapidapi.com',
        'x-rapidapi-key': '2de26ac0a2mshe6832abec6f4f0bp1928b9jsn699ea3509bb3'
      }
    };
    axios.request(options)
      .then(res => {
        if(res.data.code !== 200){
          alert("Unknown status code! Code: " + res.data.code + " with word " + res.data.text[0])
        }else{
          props.setWordlist(prev => {
            let glosa = {'en':newWord, 'sv':res.data.text[0]}
            prev.words.push(glosa)
            return prev
          })
        }
      })
      .catch(error => {
        alert(error)
      })
  }
  return (
    <>
      <h3>{props.wordlist.name}</h3>
      <Table striped hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Engelska</th>
            <th>Svenska</th>
          </tr>
        </thead>
        <tbody key={props.wordlist}>
          {props.wordlist.words.map(word => (
            <tr key={word.sv}>
              <td>{props.wordlist.words.indexOf(word) + 1}</td>
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