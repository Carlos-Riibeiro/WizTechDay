import {Selector} from 'testcafe'

export default class Page{
    constructor(){
        this.urlBase = 'http://localhost:5000';
        this.titlePages = Selector('title');
        this.toastMessage = Selector('.toast-message');
    }
}