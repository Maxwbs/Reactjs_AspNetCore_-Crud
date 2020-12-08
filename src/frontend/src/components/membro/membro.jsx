import React, { Component } from 'react'
import { Modal, Button } from 'react-bootstrap';
import Main from '../template/Main'
import axios from 'axios'

const HeardProps = {
    icon: 'users',
    title: 'Membros'
}

const baseUrl = "https://localhost:5001/api/membro";
const baseUrlCorreios = "https://viacep.com.br/ws";

const initialState = {
    membro: {
        id: '00000000-0000-0000-0000-000000000000',
        email: '',
        cargoMinisterial: '1',
        membroEhAtivo: true,
        gerarCredencial: true,
        dataBatismoEspiritoSanto: '',
        dataBatismoAguas: '',
        congregacao: '1',
        dtoEndereco: {
            cep: '',
            logradouro: '',
            complemento: '',
            bairro: '',
            localidade: '',
            uf: '',
            ddd: ''
        },
        dtoPessoa:
        {
            nome: '',
            nomePai: '',
            nomeMae: '',
            sexo: '1',
            rg: '',
            cpf: '',
            naturalidade: '',
            estadoCivil: 'NENHUM',
            orgaoEmissorRg: '',
            nacionalidade: '',
            dataNascimento: '',
        }

    },
    list: [],
    showModal: false,
    search: ''
}

export default class MembroCrud extends Component {
    state = { ...initialState }

    handleShow(valor) {

        if (valor && this.state.membro.id) {
            this.clear();
        }

        this.setState({ showModal: valor });
    }

    clear() {
        this.setState({ membro: initialState.membro })
    }

    save = () => {
        const membro = this.state.membro
        const method = membro.id !== '00000000-0000-0000-0000-000000000000' ? 'put' : 'post'
        const url = baseUrl;

        axios[method](url, membro)
            .then(resp => {
                this.setState({ membro: resp.data })
                this.clear();
                this.handleShow(false)
                this.componentWillMount()
            })
    }

    getUpdateList(membro) {
        const list = this.state.list.filter(u => u.id !== membro.id)
        list.unshift(membro)
        return list
    }

    updateCep(event) {
        const cep = event.target.value.replace('-', '');
        const membro = { ...this.state.membro }

        if (cep.length !== 8) {
            membro.dtoEndereco[event.target.name] = event.target.value;
            this.setState({ membro })
            return;
        }

        const urlCorreios = `${baseUrlCorreios}/${cep}/json`

        axios(urlCorreios).then(resp => {

            const enderecoCorreios = resp.data;

            membro.dtoEndereco.cep = enderecoCorreios.cep;
            membro.dtoEndereco.logradouro = enderecoCorreios.logradouro;
            membro.dtoEndereco.complemento = enderecoCorreios.complemento;
            membro.dtoEndereco.bairro = enderecoCorreios.bairro;
            membro.dtoEndereco.localidade = enderecoCorreios.localidade;
            membro.dtoEndereco.uf = enderecoCorreios.uf;
            membro.dtoEndereco.ddd = enderecoCorreios.ddd;

            this.setState({ membro })

        }).catch(erro => console.error(erro));

        membro.dtoEndereco[event.target.name] = event.target.value;

        this.setState({ membro })
    }

    updateField(event) {
        const membro = { ...this.state.membro }

        membro[event.target.name] = event.target.type === 'checkbox' ? event.target.checked : event.target.value
        membro.dtoPessoa[event.target.name] = event.target.type === 'checkbox' ? event.target.checked : event.target.value
        membro.dtoEndereco[event.target.name] = event.target.type === 'checkbox' ? event.target.checked : event.target.value

        this.setState({ membro })
    }

    modalCadastroOuAtualizacao() {
        return (
            <Modal
                size="lg"
                show={this.state.showModal}
                onHide={() => this.handleShow(false)}
                aria-labelledby="example-modal-sizes-title-lg"
            >
                <Modal.Header closeButton>
                    <Modal.Title id="example-modal-sizes-title-lg">
                        Cadastro de Membro
                        </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {this.renderFormDadosPessoais()}
                    {this.renderFormDadosMinistro()}
                    {this.renderFormEndereco()}
                    {this.componentesGeralButtons()}
                </Modal.Body>
            </Modal>
        );

    }

    renderFormDadosPessoais() {
        
        return (
            <div className="form alert alert-secondary">

                <div className="form-row">
                    <div className="form-group col-md-6">
                        <strong>Nome</strong>
                        <input type="text" className="form-control"
                            name="nome"
                            value={this.state.membro.dtoPessoa.nome}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                    <div className="form-group col-md-6">
                        <strong>Nome do Pai</strong>
                        <input type="text" className="form-control"
                            name="nomePai"
                            value={this.state.membro.dtoPessoa.nomePai}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                </div>
                <div className="form-row">
                    <div className="form-group col-md-6">
                        <strong>Nome da Mãe</strong>
                        <input type="text" className="form-control"
                            name="nomeMae"
                            value={this.state.membro.dtoPessoa.nomeMae}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Sexo</strong>
                        <select onChange={e => this.updateField(e)} value={this.state.membro.dtoPessoa.sexo} name="sexo" className="form-control">
                            <option defaultValue="1" selected>Masculino</option>
                            <option value="2" >Feminino</option>
                        </select>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Rg</strong>
                        <input type="text" className="form-control"
                            name="rg"
                            value={this.state.membro.dtoPessoa.rg}
                            onChange={e => this.updateField(e)}></input>
                    </div>
                </div>

                <div className="form-row">
                    <div className="form-group col-md-3">
                        <strong>Cpf</strong>
                        <input type="text" className="form-control"
                            name="cpf"
                            value={this.state.membro.dtoPessoa.cpf}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Naturalidade</strong>
                        <input type="text" className="form-control"
                            name="naturalidade"
                            value={this.state.membro.dtoPessoa.naturalidade}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Estado civil</strong>
                        <select onChange={e => this.updateField(e)} value={this.state.membro.dtoPessoa.estadoCivil} name="estadoCivil" className="form-control">
                            <option defaultValue="0" selected></option>
                            <option value="1" >Casado(a)</option>
                            <option value="2" >Solteiro(a)</option>
                            <option value="3" >Membro(a)</option>
                            <option value="4" >Viúvo(a)</option>
                            <option value="5" >Separado(a)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Orgão Emissor do RG</strong>
                        <input type="text" className="form-control"
                            name="orgaoEmissorRg"
                            value={this.state.membro.dtoPessoa.orgaoEmissorRg}
                            onChange={e => this.updateField(e)}></input>
                    </div>
                </div>

                <div className="form-row">
                    <div className="form-group col-md-3">
                        <strong>Nacionalidade</strong>
                        <input type="text" className="form-control"
                            name="nacionalidade"
                            value={this.state.membro.dtoPessoa.nacionalidade}
                            onChange={e => this.updateField(e)}></input>
                    </div>

                    <div className="form-group col-md-3">
                        <strong>Data de Nascimento</strong>
                        <input type="date" className="form-control"
                            name="dataNascimento"
                            value={this.ajusteData(this.state.membro.dtoPessoa.dataNascimento)}
                            onChange={e => this.updateField(e)}></input>
                    </div>
                </div>
            </div>
        )
    }

    renderFormDadosMinistro() {

        return (
            <>
                <div className="form alert alert-secondary">

                    <div className="form-row">
                        <div className="form-group col-md-6">
                            <strong>Email</strong>
                            <input type="text" className="form-control"
                                name="email"
                                value={this.state.membro.email}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-6">
                            <strong>Cargo Ministerial</strong>
                            <select onChange={e => this.updateField(e)} value={this.state.membro.cargoMinisterial} name="cargoMinisterial" className="form-control">
                                <option value="0" selected></option>
                                <option value="1" selected>Pastor(a)</option>
                                <option value="2" >Missionário(a)</option>
                                <option value="3" >Membro(a)</option>
                                <option value="4" >Evangelista</option>
                                <option value="5" >Presbítero</option>
                                <option value="6" >Diacono</option>
                                <option value="6" >Diaconisa</option>
                                <option value="7" >Bispo</option>
                            </select>
                        </div>

                    </div>
                    <div className="form-row ml-4">
                        <div className="custom-control custom-checkbox form-group col-md-6">
                            <label >
                                Membro Ativo
                            </label>
                            <input type="checkbox" className="ml-2"
                                name="membroEhAtivo"
                                checked={this.state.membro.membroEhAtivo}
                                onChange={e => this.updateField(e)}
                            />
                        </div>

                        <div className="custom-control custom-checkbox form-group col-md-6">
                            <label >
                                Gerar Credencial
                            </label>
                            <input type="checkbox" name="gerarCredencial" className="ml-2"
                                checked={this.state.membro.gerarCredencial}
                                onChange={e => this.updateField(e)}
                            />

                        </div>
                    </div>
                    <div className="form-row">
                        <div className="form-group col-md-4">
                            <strong>Batismo Espirito Santo</strong>
                            <input type="date" className="form-control"
                                name="dataBatismoEspiritoSanto"
                                value={this.ajusteData(this.state.membro.dataBatismoEspiritoSanto)}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-4">
                            <strong>Batismo Espirito Santo</strong>
                            <input type="date" className="form-control"
                                name="dataBatismoAguas"
                                value={this.ajusteData(this.state.membro.dataBatismoAguas)}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-4">
                            <strong>Congregação</strong>
                            <select onChange={e => this.updateField(e)} value={this.state.membro.congregacao} name="congregacao" className="form-control">
                                <option value="1" selected>Sede</option>
                                <option value="2" >Senador Canedo(filial)</option>
                            </select>
                        </div>
                    </div>
                </div>
            </>
        )
    }

    renderFormEndereco() {
        return (
            <>
                <div className="form alert alert-secondary">
                    <div className="form-row">
                        <div className="form-group col-md-4">
                            <strong>Cep</strong>
                            <input type="text" className="form-control"
                                name="cep"
                                value={this.state.membro.dtoEndereco.cep}
                                onChange={e => this.updateCep(e)}></input>
                        </div>

                        <div className="form-group col-md-8">
                            <strong>Logradouro</strong>
                            <input type="text" className="form-control"
                                name="logradouro"
                                value={this.state.membro.dtoEndereco.logradouro}
                                onChange={e => this.updateField(e)}></input>
                        </div>
                    </div>

                    <div className="form-row">
                        <div className="form-group col-md-8">
                            <strong>Complemento</strong>
                            <input type="text" className="form-control"
                                name="complemento"
                                value={this.state.membro.dtoEndereco.complemento}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-4">
                            <strong>Bairro</strong>
                            <input type="text" className="form-control"
                                name="bairro"
                                value={this.state.membro.dtoEndereco.bairro}
                                onChange={e => this.updateField(e)}></input>
                        </div>
                    </div>

                    <div className="form-row">
                        <div className="form-group col-md-8">
                            <strong>Localidade</strong>
                            <input type="text" className="form-control"
                                name="localidade"
                                value={this.state.membro.dtoEndereco.localidade}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-2">
                            <strong>Uf</strong>
                            <input type="text" className="form-control"
                                name="uf"
                                value={this.state.membro.dtoEndereco.uf}
                                onChange={e => this.updateField(e)}></input>
                        </div>

                        <div className="form-group col-md-2">
                            <strong>Ddd</strong>
                            <input type="text" className="form-control"
                                name="ddd"
                                value={this.state.membro.dtoEndereco.ddd}
                                onChange={e => this.updateField(e)}></input>
                        </div>
                    </div>
                </div>
            </>
        )
    }

    ajusteData(data) {
        if (data !== null && data && data.length > 10) {
            var datas = data.split('T');

            return datas[0];
        }

        return data;
    }

    componentesGeralButtons() {
        return (
            <>
                <hr />
                <div className="row">
                    <div className="col-12 d-flex justify-content-center">
                        {this.componenteButtonSalvar()}
                        {this.componenteButtonCancelar()}
                        {this.componenteButtonExcluir()}
                    </div>
                </div>
            </>
        )
    }

    componenteButtonSalvar() {
        return <button className="btn btn-primary" onClick={() => this.save()}>Salvar</button>
    }

    componenteButtonCancelar() {

        const habilitarButtonCancelar = this.state.membro.id === '';

        return (
            <>
                {
                    habilitarButtonCancelar
                        ? <button className="btn btn-secundary ml-2" onClick={e => this.clear(e)}> Cancelar</button>
                        : ''
                }
            </>
        )
    }

    componenteButtonExcluir() {

        const habilitarButtonExcluir = this.state.membro.id !== '';

        return (
            <>
                {
                    habilitarButtonExcluir
                        ? <button className="btn btn-danger ml-2" onClick={() => this.remove(this.state.membro)}>Excluir</button>
                        : ''
                }
            </>
        )
    }

    componentWillMount() {
        axios(baseUrl).then(resp => {
            this.setState({ list: resp.data })
        })
    }

    load(membro) {

        this.handleShow(true);

        axios(`${baseUrl}/${membro.id}`).then(resp => {
            this.setState({ membro: resp.data })
        })

        this.setState({ membro })
    }

    remove(membro) {
        axios.delete(`${baseUrl}/${membro.id}`).then(resp => {
            const list = this.state.list.filter(u => u !== membro)
            this.setState({ list })
            this.clear();
            this.handleShow(false)
            this.componentWillMount()
        })
    }

    renderTable() {
        return (<>
            <strong className="d-flex justify-content-center">Lista de Membros</strong>
            <hr />
            <input type="text" className="form-control form-control-lg" placeholder="Buscar Membro" onChange={e => this.handleSearch(e)} />
            <hr />
            <table className="table mt-2">
                <thead>
                    <tr>
                        <th>Membro</th>
                        <th>Ativo</th>
                        <th>Editar</th>
                    </tr>
                </thead>
                <tbody>
                    {this.renderRows()}
                </tbody>
            </table>
        </>
        )
    }

    handleSearch(event) {
        this.setState({ search: event.target.value })
    }

    renderRows() {

        const search = this.state.search;
        const lowercasedFilter = search.toLowerCase();
        const filteredData = this.state.list.filter(item => {
            return Object.keys(item).some(key =>
                typeof item[key] === "string" && item[key].toLowerCase().includes(lowercasedFilter)
            );
        });

        return filteredData.map((membro, index) => {
            debugger
            return (
                <tr key={index}>
                    <td>{membro.dtoPessoa.nome}</td>
                    <td>{membro.membroEhAtivo ? "Sim" : "Não"}</td>
                    <td>
                        <button className="btn btn=warning">
                            <i className="fa fa-pencil"
                                onClick={() => this.load(membro)}></i>
                        </button>
                    </td>
                </tr>
            )
        })
    }

    componenteButtonModal() {
        return <Button onClick={() => this.handleShow(true)}>Novo Membro</Button>
    }

    render() {
        return (
            <Main {...HeardProps}>
                {this.componenteButtonModal()}
                <hr />
                {this.modalCadastroOuAtualizacao()}
                {this.renderTable()}
            </Main>
        )
    }
}
