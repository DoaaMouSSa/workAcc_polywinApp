import axios from 'axios';
import Config from '../Config/Config';

const instance = axios.create({
    baseURL: Config.defaultURLDataSheet()
});

let token = window.sessionStorage.getItem("token");

instance.defaults.headers.common["Authorization"] = token;//.replace(/^"(.*)"$/, '$1');
instance.defaults.headers.post["Content-Type"] = "application/json;charset=UTF-8";
 
export default instance;