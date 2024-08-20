import React, { useEffect, useState } from 'react'
import axios from 'axios'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content';
import { show_alert } from '../functions';

const ShowClients = () => {
    const url = 'https://localhost:7050/Clientes';
    const [clients,setClients]= useState([]);
    const [id,setId]= useState('');
    const [name,setName]= useState('');
    const [email,setEmail]= useState('');
    const [documentType, setDocumentType]= useState('');
    const [documentNumber, setDocumentNumber]= useState('');
    const [registerDate, setRegisterDate]= useState('');

    useEffect( () => {
        getClients();
    }, [])

    const getClients = async () => {
        const respuesta = await axios.get(url);
        setClients(respuesta.data)
    }

  return (
    <div className='App'>
        <div className='container-fluid'>
            <div className='row mt-3'>
                <div className='col-md-4 offset-4'>
                    <div className='d-grid mx-auto'>
                        <button className='btn btn-dark' data-bs-toggle='modal' data-bs-target='#modalClients'>
                            <i className='fa-solid fa-circle-plus'></i> Añadir
                        </button>
                    </div>
                </div>
            </div>
            <div className='row mt-3'>
                <div className='col-12 col-lg-8 offset-0 offset-lg-3'>
                    <div className='table-responsive'>
                        <table className='table table-bordered'>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>CLIENTE</th>
                                    <th>EMAIL</th>
                                    <th>TIPO DE DOCUMENTO</th>
                                    <th>NÚMERO DE DOCUMENTO</th>
                                    <th>FECHA DE REGISTRO</th>
                                </tr>
                            </thead>
                            <tbody className='table-group-divider'>
                                {clients.map( (client, i) => (
                                    <tr key={client.id}>
                                        <td>{(i+1)}</td>
                                        <td>{client.name}</td>
                                        <td>{client.email}</td>
                                        <td>{client.documentType}</td>
                                        <td>{client.documentNumber}</td>
                                        <td>{client.registerDate}</td>
                                    </tr>
                                ))
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div className='modal fade'>
            
        </div>
    </div>
  )
}

export default ShowClients