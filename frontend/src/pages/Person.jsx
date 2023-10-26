import { useEffect, useState } from "react"
import { API_ENDPOINT } from '../config/consts'
import { BasicTable } from "../components/BasicTable"
import DialogModal from "../components/Dialog"

export const Person = () => {

    const PERSON_INIT_STATE= {
        id:0,
        firstName: "",
        lastName: "",
        phoneNumber: "",
        email: "",
        street:"",
        country: "",
        city: "",
        zipCode: ""
    }
    const ROUTE = '/Persons';
    const [persons, setPersons] = useState([])
    const [editIsOpen, setEditIsOpen] = useState(false)
    const [confirmDeleteOpen, setConfirmDeleteOpen] = useState(false)
    const [selectedPerson, setSelectedPerson] = useState(PERSON_INIT_STATE)

    const getAll = async () => {
        let fetchResp = await fetch(API_ENDPOINT + ROUTE)
        let dataJson = await fetchResp.json()
        setPersons(dataJson.persons)
    }

      //TODO: Create general fetch or hook
      //Handle status codes.
    const postData = async (data) => {
        let fetchResp = await fetch(API_ENDPOINT + ROUTE, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        })
        await fetchResp.json()
        await getAll()
    }

    const updateData = async (data) => {
        let fetchResp = await fetch(API_ENDPOINT + ROUTE + "/" + data.id, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        })
        await fetchResp.json()
        await getAll()
    }
    const deleteData = async (row) => {
        await fetch(API_ENDPOINT + ROUTE +"/" + row.id, {
            method: "DELETE"
        })
        await getAll()
    }
    const saveDataConfirm = async (e)=>{
        e.preventDefault();
        if (selectedPerson.id === 0){
            //Create
            await postData(selectedPerson)
            return;
        }
        else {
            await updateData(selectedPerson)
        }
        setEditIsOpen(false)
    }

    const confirmDelete = async (e) => {
        e.preventDefault()
        await deleteData(selectedPerson)
        setConfirmDeleteOpen(false)
        await getAll()
    }

    const editOnClick = (e, row) => {
        e.preventDefault();
        setEditIsOpen(true)
        setSelectedPerson(row)
    }

    const deleteOnClick = (e, row) => {
        e.preventDefault();
        setConfirmDeleteOpen(true)
        setSelectedPerson(row)
    }

    const newPersonClick = (e) => {
        e.preventDefault();
        setSelectedPerson(PERSON_INIT_STATE)
        setEditIsOpen(true)
    }

    const valueHasChanged = (e) => {
        setSelectedPerson((prev) => ({
            ...prev,
            [e.target.name]: e.target.value
        }))
    }
    useEffect(() => {
        (async () => {
            await getAll()
        })()
    }, [])

    const actionButtons = ({ row }) => {
        return (
            <>
                <button className="w3-button w3-blue" onClick={(e) => editOnClick(e, row)} >Edit</button>
                <button className="w3-button w3-red" onClick={(e)=> deleteOnClick(e,row)} >Delete</button>
            </>)
    }

    const columnsToShow = ["Id", "First name", "Last Name", "Email", "Phone", "Country", "City", "Street", "Zip"]
    return (
        <>
            <button className="w3-button w3-green w3-margin-bottom"
                onClick={newPersonClick} >Create person</button>
            <BasicTable columns={columnsToShow} data={persons} Actions={actionButtons} />
            <DialogModal title="Edit person"
                isOpened={editIsOpen}
                onClose={() => { setEditIsOpen(false) }}
                onSubmit={saveDataConfirm}
                confirmText={"Save person"}

            >
                <div className="w3-container">
                    <input type="hidden" name="id" value={selectedPerson.id} />
                    <label htmlFor="firstName">First Name</label>
                    <input className="w3-input w3-border"
                        id="firstName"
                        name="firstName"
                        type="text"
                        required={true}
                        value={selectedPerson.firstName}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="lastName">Last Name</label>
                    <input className="w3-input w3-border"
                        id="lastName"
                        name="lastName"
                        type="text"
                        required={true}
                        value={selectedPerson.lastName}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="email">Email</label>
                    <input className="w3-input w3-border"
                        id="email"
                        name="email"
                        type="text"
                        required={true}
                        value={selectedPerson.email}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="phoneNumber">Phone number</label>
                    <input className="w3-input w3-border"
                        id="phoneNumber"
                        name="phoneNumber"
                        type="text"
                        required={true}
                        value={selectedPerson.phoneNumber}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="country">Country</label>
                    <input className="w3-input w3-border"
                        id="country"
                        name="country"
                        type="text"
                        required={true}
                        value={selectedPerson.country}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="street">Street</label>
                    <input className="w3-input w3-border"
                        id="street"
                        name="street"
                        type="text"
                        required={true}
                        value={selectedPerson.street}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="city">City</label>
                    <input className="w3-input w3-border"
                        id="city"
                        name="city"
                        type="text"
                        required={true}
                        value={selectedPerson.city}
                        onChange={valueHasChanged}
                    />
                    <label htmlFor="zipCode">Zip code</label>
                    <input className="w3-input w3-border"
                        id="zipCode"
                        name="zipCode"
                        type="text"
                        required={true}
                        value={selectedPerson.zipCode}
                        onChange={valueHasChanged}
                    />
                </div>
            </DialogModal>

            <DialogModal title="Deletion confirm"
                isOpened={confirmDeleteOpen}
                onSubmit={confirmDelete}
                onClose={() => { setConfirmDeleteOpen(false) }}
                confirmText={"Confirm"}
            >
                <p>Are you sure about delete <b>{selectedPerson.firstName} {selectedPerson.lastName}</b>?</p>
            </DialogModal>
        </>
    )
}