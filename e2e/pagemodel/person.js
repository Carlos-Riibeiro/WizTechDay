import { Selector } from 'testcafe'
import Page from './page'

export default class Person extends Page{
    constructor(){
        super();
        this.urlList = `${this.urlBase}/Person/index`;
        this.urlCreate =  `${this.urlBase}/Person/Create`;
        this.subtitlePage = Selector('[id="subtitle-person"]');
        this.inputName = Selector('[name="Name"]');
        this.inputCpf = Selector('[name="Cpf"]');
        this.inputEmail = Selector('[name="Email"]');
        this.editFirsElementList = Selector('[id="edit-person+1"]');
        this.deletefirsElementList = Selector('[id="delete-person+1"]');
        this.btnEdit = Selector('[id="btn-edit"]');
        this.btnDelete = Selector('[id="btn-delete"]');
    }
}