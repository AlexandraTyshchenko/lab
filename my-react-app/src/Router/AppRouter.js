import React from 'react'
import { Routes, Route } from 'react-router-dom'
import GroupPage from '../pages/GroupPage'


function AppRouter() {
  return (
    <Routes>
     <Route path="/groups" element={<GroupPage />} />
  </Routes>
  )
}

export default AppRouter
