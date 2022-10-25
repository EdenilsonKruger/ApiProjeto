import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { pessoas: [], loading: true };
    }

    componentDidMount() {
        this.populatePessoaData();
    }

    static renderPessoasTable(pessoas) {
        const handleEditar = (index, e) => {
            debugger;
        };

        const handleVisualizar = (index, e) => {
            debugger;
        };

        const handleExcluir = (index, e) => {
            debugger;
        };

        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>CPF/CNPJ</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {pessoas.map(pessoa =>
                        <tr key={pessoa.id}>
                            <td>{pessoa.id}</td>
                            <td>{pessoa.nome_Fantasia}</td>
                            <td>{pessoa.cnpj_Cpf}</td>
                            <td>
                                <button onClick={e => handleEditar(pessoa.id, e)}>Editar</a> |
                                <button onClick={e => handleVisualizar(pessoa.id, e)}>Visualizar</a> |
                                <button onClick={e => handleExcluir(pessoa.id, e)}>Excluir</a>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderPessoasTable(this.state.pessoas);

        return (
            <div>
                <button onClick={activateLasers}>
                    Activate Lasers
                </button>
                <h1 id="tabelLabel">Pessoa</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populatePessoaData() {
        const response = await fetch('pessoa');
        const data = await response.json();
        this.setState({ pessoas: data, loading: false });
    }

    ////Excluir
    //handleDelete = (rowId) => {
    //    debugger;

    //    // Array.prototype.filter returns new array
    //    // so we aren't mutating state here
    //    const arrayCopy = this.state.data.filter((row) => row.id !== rowId);
    //    this.setState({ data: arrayCopy });
    //};
}