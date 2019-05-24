import { Selector } from 'testcafe'
import Page from './page'

export default class Person extends Page{
    constructor(){
        super();
        this.url =  `${this.urlBase}/Person/Create`;
        this.subtitlePage = Selector('[id="subtitle-person"]');
        this.inputName = Selector('[name="Name"]');
        this.inputCpf = Selector('[name="Cpf"]');
        this.inputEmail = Selector('[name="Email"]');
        this.btnSave = Selector('.btn-success');
    }
}