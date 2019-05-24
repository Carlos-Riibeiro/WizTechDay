import { Selector } from 'testcafe'
import Page from './page'

export default class Home extends Page {
    constructor() {
        super();
        this.url = this.urlBase;
        this.linkPagePerson = Selector('[id="navigate-person"]')
    }
}