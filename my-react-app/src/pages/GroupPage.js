import React, { useEffect, useState } from 'react';
import GroupService from '../services/GroupService';


function GroupPage() {
  const [groups, setGroups] = useState([]);
  const [error, setError] = useState();

  async function fetchData() {
    try {
      const response = await GroupService.getAll(); // Call getAll from GroupService
      setGroups(response);
      console.log(groups);
    } catch (error) {
      setError(error.message);
    }
  }

  return (
    <div>
      <button onClick={() => fetchData()}>
        Fetch Data
      </button>
    </div>
  );
}

export default GroupPage;
