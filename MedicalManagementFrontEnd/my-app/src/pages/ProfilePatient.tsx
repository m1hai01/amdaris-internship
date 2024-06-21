/* eslint-disable @typescript-eslint/no-explicit-any */
// src/pages/PatientProfile.tsx
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Users } from "../api/axios";
import {
  Box,
  Card,
  CardContent,
  DialogContent,
  Typography,
} from "@mui/material";
import CreateTreatmentForm from "../components/UI/CreateTreatmentForm";
import ViewTreatment from "../components/UI/ViewTreatment";
import AddDiagnosisForm from "../components/UI/AddDiagnosisForm";
import { DataGrid, GridColDef, GridPaginationModel } from "@mui/x-data-grid";
import CircularProgress from "@mui/material/CircularProgress";
import CustomModal from "../components/UI/CustomModal/CustomModal";
import AddBoxIcon from "@mui/icons-material/AddBox";
import Dropzone from "../components/UI/Dropzone/Dropzone";
import PageviewIcon from "@mui/icons-material/Pageview";

const ProfilePatient: React.FC = () => {
  const { patientId } = useParams<{ patientId: string }>();
  const [patient, setPatient] = useState<any>(null);
  const [diagnoses, setDiagnoses] = useState<any[]>([]);
  const [selectedTreatment, setSelectedTreatment] = useState<any>(null);
  const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({
    pageSize: 5,
    page: 0,
  });

  useEffect(() => {
    const fetchPatient = async () => {
      try {
        const response = await Users.getUserById(patientId!);
        setPatient(response);
      } catch (error) {
        console.error("Error fetching patient details:", error);
      }
    };

    fetchDiagnoses();
    fetchPatient();
  }, [patientId]);

  // create a fetch method for diagnoses

  const fetchDiagnoses = async () => {
    await Users.getPatientWithDiagnoses(patientId!).then((response) => {
      const { medicalCard } = response;
      const diagnoses = medicalCard.medicalRecords[0].diagnoses.flat().map(d => d.diagnose);

      setDiagnoses(diagnoses);
    });
  };

  console.log(diagnoses);

  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 200 },
    {
      field: "name",
      headerName: "Diagnosis",
      width: 500,
      valueGetter: (params: any) => params,
    },
    {
      field: "treatment",
      headerName: "Treatment",
      width: 170,
      renderCell: (_) => (
        <Box display="flex" gap={2}>
          <CustomModal
            modalName="Create Treatment"
            tooltipTitle="Create Treatment"
            buttonStyle={{ marginTop: "10px", backgroundColor: "#f0eeee" }}
            icon={<AddBoxIcon />}
            modalContent={
              <>
                <DialogContent>
                  <CreateTreatmentForm
                    patientId={patientId!}
                    onClose={() => setOpenCreateTreatment(false)}
                  />
                </DialogContent>
              </>
            }
          />
          <CustomModal
            modalName="View Treatment"
            tooltipTitle="View Treatment"
            icon={<PageviewIcon />}
            buttonStyle={{ marginTop: "10px", backgroundColor: "#f0eeee" }}
            modalContent={
              <>
                <DialogContent>
                  <ViewTreatment treatment={selectedTreatment} />
                </DialogContent>
              </>
            }
          />
        </Box>
      ),
    },
    {
      field: "files",
      headerName: "Attached Files",
      width: 200,
      renderCell: (params) => {
        console.log("🚀 ~ params:", params);

        return (
          <CustomModal
            modalName="Attached Files"
            buttonStyle={{ backgroundColor: "#f0eeee" }}
            modalContent={<Dropzone id={params.id} files={params.row.diagnoseFiles} />}
          />
        );
      },
    },
  ];

  if (!patient) {
    return (
      <Box sx={{ display: "flex" }}>
        <CircularProgress />
      </Box>
    );
  }

  return (
    <Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          flexDirection: "column",
          gap: "20px",
          marginTop: "20px",
        }}
      >
        <Card
          variant="outlined"
          sx={{ alignSelf: "flex-start", width: "30%", marginLeft: 8 }}
        >
          <CardContent>
            <Typography variant="h5">{patient.name}'s Profile</Typography>
            <Typography variant="body1">
              <strong>Username</strong>: {patient.username}
            </Typography>
            <Typography variant="body1">
              <strong>Email</strong>: {patient.email}
            </Typography>
            <Typography variant="body1">
              <strong>Phone Number</strong>: {patient.phoneNumber}
            </Typography>
            <Typography variant="body1">
              <strong>Date of Birth</strong>:{" "}
              {new Date(patient.dateOfBirth).toLocaleDateString()}
            </Typography>
            <Typography variant="body1">
              <strong>Gender</strong>:{" "}
              {patient.gender === 0 ? "Male" : "Female"}
            </Typography>
          </CardContent>
        </Card>
      </Box>

      <Box
        style={{ margin: 4 }}
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
      >
        <Box width="90%">
          <Typography variant="h5" mt={2}>
            Diagnoses
          </Typography>
          <DataGrid
            rows={diagnoses}
            columns={columns}
            paginationModel={paginationModel}
            onPaginationModelChange={setPaginationModel}
            sx={{ backgroundColor: "#f0eeee", minWidth: "800px" }}
          />
          <CustomModal
            modalName="Add Diagnosis"
            buttonText="Add Diagnosis"
            buttonStyle={{ marginTop: "10px", backgroundColor: "#f0eeee" }}
            modalContent={
              <>
                <DialogContent>
                  <AddDiagnosisForm patientId={patientId!} refetch={fetchDiagnoses} />
                </DialogContent>
              </>
            }
          />
        </Box>
      </Box>
    </Box>
  );
};

export default ProfilePatient;
