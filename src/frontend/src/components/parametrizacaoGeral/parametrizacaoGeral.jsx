import React, { Component } from 'react'
import Main from '../template/Main'
import axios from 'axios'

const HeardProps = {
    icon: 'users',
    title: 'Parametrização Credencial'
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

export default class dtoParametrizacaoGeral extends Component {
    state = { ...initialState }

    clear() {
        this.setState({ dtoParametrizacaoGeral: initialState.dtoParametrizacaoGeral })
    }

    changeFile = (e) => {
        
        const dtoParametrizacaoGeral = { ...this.state.dtoParametrizacaoGeral }

        let readerArq = new FileReader();
        let file = e.target.files[0];

        readerArq.onloadend = r => {
            let imgResult = r.target.result

            dtoParametrizacaoGeral.descricao = file.name;
            dtoParametrizacaoGeral.extensao = '';
            dtoParametrizacaoGeral.tamanho = file.size;
            dtoParametrizacaoGeral.contentType = file.type;
            dtoParametrizacaoGeral.imagem = imgResult;
            this.setState({ dtoParametrizacaoGeral });
        }

        readerArq.readAsDataURL(file)
        this.setState({ showImage: false })
    }

    imageShow = () => {
        return (
            <div>
                <img src={this.state.dtoParametrizacaoGeral.imagem} style={{ width: 400 }} alt="Imagem" />
            </div>
        )
    }

    renderForm() {
        const habilitarExcluir = this.state.dtoParametrizacaoGeral.imagem !== '';  

        return <>
            <div className="form-row">
                <div className="form-group col-md-1">
                    {this.componenteButtonSalvar()}                        
                </div>  

                <div className="form-group col-md-11">                    
                     { habilitarExcluir ? this.componenteButtonExcluir() : '' }
                </div>              
            </div>
            <hr/>
            <div className="form-group">
                    <p className="App-intro mt-2">
                        <input type="file" name="file" accept=".jpeg, .png, .jpg" value={this.state.file} onChange={this.changeFile} />
                    </p>
            </div>
            <hr />
            {this.state.showImage && (this.imageShow())}
        </>
    }

    save = () => {
        var dtoParametrizacaoGeral = { ...this.state.dtoParametrizacaoGeral }
        axios.post(baseUrl, dtoParametrizacaoGeral)
            .then(() => {
                this.setState({ showImage: true })
            }).catch(() => {
                this.setState({ showImage: false })
            })
    }

    delete = () => {         
        const urlDelete = baseUrl + '/deleteall';
        axios.post(urlDelete)
            .then(() => {
                
                this.setState({ showImage: false })
            }).catch(() => {
                this.setState({ showImage: false })
            })
    }

    componenteButtonSalvar() {
        return <button className="btn btn-primary" id ="btnsalvar" onClick={() => this.save()}>Salvar</button>
    }

    componenteButtonExcluir() {
        return <button className="btn btn-danger" id="btnexcluir" onClick={() => this.delete()}>Excluir</button>
    }

    componentWillMount() {
        const dtoParametrizacaoGeral = { ...this.state.dtoParametrizacaoGeral }

        axios(baseUrl).then(resp => {
            if(resp.data.length <= 0)
            {
                return;
            }

            dtoParametrizacaoGeral.descricao = resp.data[0].descricao;
            dtoParametrizacaoGeral.extensao = resp.data[0].extensao;
            dtoParametrizacaoGeral.tamanho = resp.data[0].tamanho;
            dtoParametrizacaoGeral.contentType = resp.data[0].contentType;
            dtoParametrizacaoGeral.imagem = resp.data[0].imagem;

            this.setState({ dtoParametrizacaoGeral });
            this.setState({ showImage: true })
            this.renderForm()
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
