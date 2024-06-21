import { Box, SxProps } from "@mui/material";
import Modal from "@mui/material/Modal";
import Typography from "@mui/material/Typography";
import React, { ReactElement, cloneElement, useState } from "react";
import AttachFileIcon from "@mui/icons-material/AttachFile";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";
import "./custom-modal.styles.css";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";

interface CustomModalProps {
  modalContent?: ReactElement;
  modalName?: string;
  tooltipTitle?: string;
  icon?: ReactElement;
  buttonStyle?: SxProps;
  modalStyle?: SxProps;
  disabled?: boolean;
  buttonText?: string;
  isVisible?: boolean;
}


const CustomModal = ({
  modalContent = <></>,
  modalName = "Modal",
  tooltipTitle = "Open modal",
  icon = undefined,
  buttonStyle = undefined,
  modalStyle = undefined,
  disabled = false,
  buttonText = "",
  isVisible = true,
}: CustomModalProps): ReactElement => {
  const [open, setOpen] = useState(false);

  const handleOpen = (): void => {
    if (isVisible) {
      setOpen(true);
    }
  };

  const handleClose = (): void => {
    setOpen(false);
  };

  const buttonIcon = icon ? icon : <AttachFileIcon />;

  return (
    <>
      <Button
        onClick={handleOpen}
        aria-label="open modal"
        size="medium"
        sx={buttonStyle}
        disabled={disabled}
      >
        <Tooltip sx={{ fontSize: "20px" }} arrow title={tooltipTitle}>
          {buttonText ? <Typography color="black">{buttonText}</Typography> : buttonIcon}
        </Tooltip>
      </Button>
      <Modal
        open={open}
        onClose={handleClose}
        keepMounted
        aria-labelledby="modal-title"
      >
        <Box className="modal-content" sx={modalStyle}>
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Typography
              variant="h5"
              style={{
                textTransform: "uppercase",
                textAlign: "center",
                margin: "0 auto",
                paddingLeft: "35px",
              }}
              id="modal-title"
            >
              {modalName}
            </Typography>
            <IconButton onClick={handleClose} aria-label="close modal">
              <CloseIcon />
            </IconButton>
          </Box>
          {modalContent &&
            React.Children.map(modalContent, (child) => {
              return cloneElement(child, { onClose: handleClose });
            })}
        </Box>
      </Modal>
    </>
  );
};

export default CustomModal;
