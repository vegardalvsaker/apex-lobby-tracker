import React from 'react'

const App: React.FC = () => {
    const handleImageUpload = () => {
        console.log('image')
    }

    return (
        <div>
            <h1>Apex Lobby Tracker</h1>
            <h3>Upload image of lobby</h3>
            <input
                type="file"
                accept="image/*"
                onChange={() => handleImageUpload()}
            />
        </div>
    )
}

export default App
