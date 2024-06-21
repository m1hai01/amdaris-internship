import { Box } from "@mui/material";
import IconButton from "@mui/material/IconButton";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import CloseIcon from "@mui/icons-material/Close";
import "./dropzone.styles.css";
import { ReactElement } from "react";
import DownloadIcon from "@mui/icons-material/Download";

export interface IUploadFileEntity extends File {
  id: string;
  fileName: string;
  contentType: string;
  uri: string | undefined;
}

interface IDropzoneItemProps {
  files: IUploadFileEntity[];
  onRemove?: (file: IUploadFileEntity) => void;
  isUpload?: boolean;
}

const DropzoneItem = ({ files, onRemove, isUpload }: IDropzoneItemProps): ReactElement => {
  const onDownload = (file: IUploadFileEntity): void => {

    const link = document.createElement("a");
    link.download = file.fileName;
    link.href = file.uri || "";
    link.click();
  };

  const getFileThumbnail = (file: IUploadFileEntity): string => {
    switch (file.contentType) {
      default:
        return file.uri || "";
    }
  };

  console.log(files)

  return (
    <Box
      sx={{
        maxHeight: isUpload ? "250px" : "400px",
        overflow: "auto",
        ...{
              "&::-webkit-scrollbar": {
                width: "10px",
              },

              "&::-webkit-scrollbar-thumb": {
                background: `linear-gradient(45deg, #404040);`,
                borderRadius: "10px",
                borderLeft: `2px solid #404040`,
              },
            },
      }}
    >
      <List
        style={{
          width: "100%",
          height: "100%",
        }}
      >
        {files?.map((file) => (
          <ListItem
            key={file.id}
            secondaryAction={
              onRemove && (
                <IconButton edge="end" aria-label="delete file" onClick={() => onRemove(file)}>
                  <CloseIcon />
                </IconButton>
              )
            }
            className="dropzone-file"
          >
            <Box
              component="img"
              sx={{
                width: 50,
                height: 50,
                marginRight: 3,
              }}
              alt={file.fileName}
              src={getFileThumbnail(file)}
            />

            <ListItemText
              primary={file.fileName}
              primaryTypographyProps={{
                whiteSpace: "nowrap",
                overflow: "hidden",
                textOverflow: "ellipsis",
                maxWidth: "300px",
              }}
            />

            <IconButton
              aria-label="download file"
              onClick={() => onDownload(file)}
              sx={{ marginRight: "10px" }}
            >
              <DownloadIcon />
            </IconButton>
          </ListItem>
        ))}
      </List>
    </Box>
  );
};

export default DropzoneItem;
