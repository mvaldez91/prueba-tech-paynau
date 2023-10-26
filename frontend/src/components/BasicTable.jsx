export const BasicTable = ({columns, data, Actions}) => {
    const keys = data.length > 0 ? Object.keys(data[0]) : []
    return (<>
        <table className="w3-table w3-striped w3-bordered w3-border">
            <thead>
                <tr>
                    {columns.map(c=> (
                        <th key={c}>{c}</th>
                    ))}
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {data.map(d=>(
                    <tr key={"tr"+d.id}>
                        {keys.map(k=>(
                            <td key={k+ "_" + d.id}>{d[k]}</td>
                        ))}
                        <td><Actions row={d}/></td>
                    </tr>
                ))}
            </tbody>
        </table>
    </>)
}