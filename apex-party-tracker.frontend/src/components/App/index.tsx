import React from 'react'
import styles from './styles.module.css'
import Navbar from '../Navbar'

const url = 'https://localhost:44379/api'

const App: React.FC = () => {
    const imageUpload = (files: FileList | null) => {
        try {
            const formData = new FormData()
            if (!files) return
            let file = files[0]
            let filename = file.name

            formData.append('file', file, filename)
            fetch(`${url}/party?user=vikjard`, {
                method: 'POST',
                body: formData,
            })
            console.log('nå skjer det ting her')
        } catch (ex) {
            console.log(`Error uploading image: ${ex}`)
        }
        console.log('nå skjer det ting her')
    }

    return (
        <>
            <Navbar />
            <div className={styles.container}>
                <h1>Apex Party Tracker</h1>
                <h3>Upload image of party</h3>
                <input
                    type="file"
                    accept="image/*"
                    onChange={e => imageUpload(e.target.files)}
                />
            </div>
        </>
    )
}

export default App
