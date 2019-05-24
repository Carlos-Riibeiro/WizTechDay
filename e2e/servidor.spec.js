import {Selector} from 'testcafe'
import Page from './pagemodel/page'

const pageBase = new Page();

fixture('Servidor')
    .page(pageBase.urlBase);

test('Sistema executando', async t =>  {

    await t.expect(pageBase.titlePages.innerText).eql('Home Page - WizTechDay');

});