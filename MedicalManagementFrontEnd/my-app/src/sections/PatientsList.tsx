/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from "react";
import { Users } from "../api/axios";
import { useNavigate } from "react-router-dom";
import { Box } from "@mui/material";
import { GridPaginationModel, GridColDef, DataGrid } from "@mui/x-data-grid";

const PatientsList: React.FC = () => {
  const [patients, setPatients] = useState([]);
  const navigate = useNavigate();
  const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({
    pageSize: 5,
    page: 0,
  });

  useEffect(() => {
    const fetchPatients = async () => {
      try {
        const response = await Users.getAllPatients({
          Page: 1,
          PageSize: 1000,
        });
        setPatients(response.data);
      } catch (error) {
        console.error("Error fetching patients:", error);
      }
    };

    fetchPatients();
  }, []);

  const handlePatientClick = (id: string) => {
    navigate(`/patients/${id}`);
  };

  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 100 },
    {
      field: "username",
      headerName: "Patient name",
      width: 200,
      valueGetter: (params: any) => params,
    },
    {
      field: "phoneNumber",
      headerName: "Phone number",
      width: 400,
    },
    {
      field: "email",
      headerName: "Email",
      width: 400,
    },
  ];

  return (
    <Box>
      <DataGrid
        rows={patients}
        columns={columns}
        paginationModel={paginationModel}
        onPaginationModelChange={setPaginationModel}
        onRowClick={(params) => handlePatientClick(params.row.id)}
        sx={{ backgroundColor: "#f0eeee" }}
      />
    </Box>
  );
};

export default PatientsList;
