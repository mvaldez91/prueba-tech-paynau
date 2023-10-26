import { useEffect, useState } from "react"
import { API_ENDPOINT } from '../config/consts'
import { BasicTable } from "../components/BasicTable"
import DialogModal from "../components/Dialog"

export const Person = () => {

    const [persons, setPersons] = useState([])
    const [editIsOpen, setEditIsOpen] = useState(false)
    const [selectedPerson, setSelectedPerson] = useState({})
    const getAll = async () => {
        let fetchResp = await fetch(API_ENDPOINT + "/Persons")
        let dataJson = await fetchResp.json()
        setPersons(dataJson.persons)
    }

    const editOnClick =  async (e,row)=>{
        e.preventDefault();
        setEditIsOpen(true)
        setSelectedPerson(row)
    }
    useEffect(() => {
        (async () => {
            await getAll()
        })()
    }, [])
    
    const actionButtons = ({row}) => {
        return (
            <>
                <button className="w3-button w3-blue" onClick={(e)=>editOnClick(e,row)} >Edit</button>
                <button className="w3-button w3-red" type="submit" action="Delete">Delete</button>
            </>)
    }

    const columnsToShow = ["Id", "First name", "Last Name", "Email", "Phone", "Country", "City", "Street", "Zip"]
    return (
        <>
            <BasicTable columns={columnsToShow} data={persons} Actions={actionButtons} />
            <DialogModal title="Edit person" 
                         isOpened={editIsOpen} 
                         onProceed={()=>{}}
                         onClose={()=>{setEditIsOpen(false)}}
                         confirmText={"Save person"}
                         
                         >
                    Id: {selectedPerson.id}
            </DialogModal>
        </>
    )
}