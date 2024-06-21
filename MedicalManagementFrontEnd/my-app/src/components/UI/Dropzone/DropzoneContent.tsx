import { Box, Typography } from "@mui/material";
import FileUploadIcon from "@mui/icons-material/FileUpload";
import { ReactElement } from "react";
import "./dropzone.styles.css";
import { DropzoneInputProps, DropzoneRootProps } from "react-dropzone";

interface IDropzoneContentProps {
  getRootProps: <T extends DropzoneRootProps>(props?: T) => T;
  getInputProps: <T extends DropzoneInputProps>(props?: T) => T;
  isDragActive: boolean;
}

export const DropzoneContent = ({
  getRootProps,
  getInputProps,
  isDragActive,
}: IDropzoneContentProps): ReactElement => {
  return (
    <>
      <Box
        {...getRootProps({ className: "dropzone" })}
        className={isDragActive ? "rootBox rootBox__isDragActive" : "rootBox"}
      >
        <input className="inputZone" {...getInputProps()} />
        <Box
          className="text-center"
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <FileUploadIcon className="dropzone-icon" />
          <Typography className="dropzone-content">
            Drag and drop some files here, or click to select files
          </Typography>
        </Box>
      </Box>
      <Typography
        variant="h5"
        component="h2"
        style={{
          textTransform: "uppercase",
          display: "flex",
          justifyContent: "center",
          marginTop: "25px",
        }}
      >
        Uploaded&nbsp;
        <strong>Files</strong>
      </Typography>
    </>
  );
};
