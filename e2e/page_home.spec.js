import Home from './pagemodel/home'
import Page from './pagemodel/page'

const pageHome = new Home();
const PageBase = new Page();

fixture('Home')
    .page(pageHome.url);

test('Carrega página inicial', async t => {

    await t.
        click(pageHome.linkPagePerson);

    await t.
        expect(PageBase.titlePages.innerText).eql("Person - WizTechDay");
});