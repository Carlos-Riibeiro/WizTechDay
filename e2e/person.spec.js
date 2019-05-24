import { Selector } from 'testcafe'
import Person from './pagemodel/person'
import CpfGenerator from 'gerador-validador-cpf'

const person = new Person();

fixture('Person')
    .page(person.url);

test('Deve criar um novo curso', async t => {

    await t
        .typeText(person.inputName, `José ${new Date().toString()}`);

    await t
        .wait(2000);

    await t
        .typeText(person.inputCpf, CpfGenerator.format(CpfGenerator.generate(), 'digits'));

    await t
        .wait(2000);

    await t
        .typeText(person.inputEmail, 'teste@teste.com')
        .click(Selector('.btn-success'))
        .takeScreenshot();

    await t
        .expect(person.subtitlePage.innerText).eql('Lista de pessoas')
})