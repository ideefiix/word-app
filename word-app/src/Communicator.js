import axios from "axios";

axios.defaults.baseURL = process.env.REACT_APP_PRODUCTION ? "https://localhost:5001" : "https://localhost:7006";
// TOKEN IMPLEMENT LATER
/* axios.interceptors.request.use(function (config) {
    const token = `Bearer ${sessionStorage.getItem('AUTH_TOKEN')}`;
    config.headers.Authorization = token;

    return config;
}); */
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

export async function db_fetchWordsInList(id){
    let response = await axios.get(`/WordList/${id}`)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
        })
    return response;
}
export async function db_addWordToList(id, word){
    let response = await axios.post(`/WordList/${id}`, {
        Sv: "None",
        En: word,
        InListId: id
    })
    .catch(error => {
        console.log("Error ", error);
    })
    return response
}
export async function db_fetchAllLists(){
    let response = await axios.get(`/WordList`)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
            response = null;
        })
    return response;
}
export async function db_createList(name){
    let response = await axios.post(`/Wordlist`, {
        name: name
    }).catch(error => {
        console.log("Error: " + error);
        response = null
    })
    return response
}