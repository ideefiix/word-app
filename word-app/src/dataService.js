

function getLists() {
  let data = fs.readFileSync('data.json')
  let lists = JSON.parse(data)

  return lists
}

function getList(listName) {
  let data = fs.readFileSync('data.json')
  let lists = JSON.parse(data)

  lists.forEach(list => {
    if (list.name == listName) return list
  });

  return []
}


function addList(list) {
  // Read content of file
  let data = fs.readFileSync('data.json')
  let lists = JSON.parse(data)
  console.log("Data in file were " );
  console.log(lists);
  // Add list
  lists.push(list)
  // Write it back
  let newData = JSON.stringify(lists)
  fs.writeFileSync('data.json', newData)

  console.log("List added");
}

function addWord(listName, word) {
  // Read content of file
  let data = fs.readFileSync('data.json')
  let lists = JSON.parse(data)
  //Find list
  lists.forEach(list => {
    if (list.name = listName) {
      list.words.push(word)

      let newData = JSON.stringify(lists)
      fs.writeFileSync('data.json', newData)
      return console.log("Word added to list " + listName);
    }
  });

}

export {getLists, getList, addList, addWord}


/* 
Lista object:
{
 name: "Lista 1",
 timeCreated: Date.now() - 50,
 words:[{sv:"test",en:"test"},
  {sv:"bajs",en:"poop"}] 

} */