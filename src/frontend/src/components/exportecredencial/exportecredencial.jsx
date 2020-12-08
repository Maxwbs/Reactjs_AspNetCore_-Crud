import React, { Component } from 'react'
import Main from '../template/Main'
import axios from 'axios'
import jsppdf from 'jspdf'

const HeardProps = {
    icon: 'users',
    title: 'Gere Credencial'
}

// Localizando nosso banco
const baseUrl = "https://localhost:5001/api/parametrizacaoGeral";

// Estado inicial - Quando sobe a aplicação
const initialState = {
    dtoParametrizacaoGeral: {
        descricao: '',
        extensao: '',
        tamanho: '',
        imagem: '',
        contentType: ''
    },
    list: [],
    showImage: false
}

export default class exportecredencial extends Component {
    state = { ...initialState }

    clear() {
        this.setState({ dtoParametrizacaoGeral: initialState.dtoParametrizacaoGeral })
    }

    renderForm() {

        return <>
            <div className="form-row">
                <div className="form-group col-md-1">
                    {this.componenteButtonExporteCredencial()}
                </div>
            </div>

        </>
    }

    gereCredencial = () => {

        var doc = new jsppdf('p', 'pt');
        doc.text(20, 20, 'Aqui esta o text defaltyi');
        doc.setFont('courier');
        // doc.setFontType('normal');        
        doc.text(20, 30, 'Aqui esta o text defaltyi fonte courier');

        doc.save("credencial.pdf");

    }

    componenteButtonExporteCredencial() {
        return <button className="btn btn-primary" id="btngerecredencial" onClick={() => this.gereCredencial()}>Gere Credencial</button>
    }


    componentWillMount() {
        // const dtoParametrizacaoGeral = { ...this.state.dtoParametrizacaoGeral }

        axios(baseUrl).then(resp => {

        })
    }

    render() {
        return (
            <Main {...HeardProps}>
                {this.renderForm()}
            </Main>
        )
    }
}
