import { Selector } from 'testcafe'
import Person from './pagemodel/person'
import CpfGenerator from 'gerador-validador-cpf'

const person = new Person();

fixture('Person')
    .page(person.urlList);

test('Deve criar um novo registro de pessoa', async t => {

    await t
        .navigateTo(person.urlCreate);

    await t
        .typeText(person.inputName, "Esmarley");

    await t
        .wait(2000);

    await t
        .typeText(person.inputCpf, CpfGenerator.format(CpfGenerator.generate(), 'digits'));

    await t
        .wait(2000);

    await t
        .typeText(person.inputEmail, 'esmarley@wizsolucoes.com.br')
        .click(Selector('.btn-success'))
        .takeScreenshot();

    await t
        .expect(person.subtitlePage.innerText).eql('Lista de pessoas')
});

test('Deve editar o primeiro registro da lista', async t => {

    await t
        .click(person.editFirsElementList);

    await t
        .typeText(person.inputName, " Oliveira")
        .click(person.inputCpf).pressKey('ctrl+a delete')
        .typeText(person.inputCpf, CpfGenerator.format(CpfGenerator.generate(), 'digits'))
        .click(person.inputEmail).pressKey('ctrl+a delete')
        .typeText(person.inputEmail, `esmarleyoliveira@wizsolucoes.com.br`)
        .click(person.btnEdit);

});

test('Deve deletar o primeiro registro da lista', async t => {

    await t
        .wait(5000)
        .click(person.deletefirsElementList);

    await t
        .click(person.btnDelete);

    await t
        .wait(5000);

});