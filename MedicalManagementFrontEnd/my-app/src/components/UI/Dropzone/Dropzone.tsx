import { ReactElement, useCallback, useState } from "react";
import { useDropzone, ErrorCode } from "react-dropzone";

import "./dropzone.styles.css";
import displaySuccessSnackbar from "./DropzoneSuccessSnackbar";
import displayErrorSnackbar from "./DropzoneErrorSnackbar";
import onDropRejected from "./OnDropRejected";
import { acceptedFiles } from "./AcceptedFiles";
import { DropzoneContent } from "./DropzoneContent";
import DropzoneItem, { IUploadFileEntity } from "./DropzoneItem";
import {
  DropzoneSuccessCodes,
  DropzoneErrorCodes,
  dropzoneErrorsToMessagesMap,
} from "./dropzone-error-Codes";
import axios from "axios";
import { Files } from "../../../api/axios";

// interface IProps {
//   taskId: string;
//   actionFiles: IUploadFileEntity[];
//   setTaskFileLength: (x: number) => void;
// }

export const FILES_COUNT = 5;
const FILE_SIZE = 10_000_000;

interface IProps {
  id: string | number;
  files: IUploadFileEntity[];
}

const Dropzone = ({ id, files }: IProps): ReactElement => {
  const [uploadedFiles, setUploadedFiles] = useState<IUploadFileEntity[]>(files || []);

  const fetchUploadedFiles = async (): Promise<void> => {};

  const onSubmit = async (files: IUploadFileEntity[]): Promise<void> => {
    const formData = new FormData();
    files.forEach((file) => {
      formData.append(`file`, file);
    });

    await Files.upload(formData, id)
      .then((response) => {
        console.log("🚀 ~ .then ~ response:", response);
        const { data } = response;
        setUploadedFiles([data]);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const onDrop = useCallback(
    (addedFiles: File[]) => {
      if (uploadedFiles.length + addedFiles.length <= FILES_COUNT) {
        const newAcceptedFiles: IUploadFileEntity[] = [];

        addedFiles.forEach((file) => {
          const isFileUploaded = uploadedFiles.some(
            (uploadedFile) => uploadedFile.fileName === file.name
          );

          if (isFileUploaded === true) {
            displayErrorSnackbar(DropzoneErrorCodes.FileUploaded);
          } else {
            newAcceptedFiles.push(
              Object.assign(file, {
                id: file.lastModified.toString(),
                fileName: file.name,
                contentType: file.type,
                uri: "",
              })
            );
          }
        });

        if (newAcceptedFiles.length > 0) onSubmit(newAcceptedFiles);
      } else {
        displayErrorSnackbar(
          dropzoneErrorsToMessagesMap.get(ErrorCode.TooManyFiles)!
        );
      }
    },
    [uploadedFiles]
  );

  const removeUploadedFile = async (file: IUploadFileEntity): Promise<void> => {
    // await endpoints
    //   .DeleteFile(file.id)
    //   .then(() => {
    //     const updatedFiles = [...uploadedFiles];
    //     updatedFiles.splice(updatedFiles.indexOf(file), 1);
    //     setUploadedFiles(updatedFiles);
    //     displaySuccessSnackbar(DropzoneSuccessCodes.FileDeleted);
    //     setTaskFileLength(updatedFiles.length);
    //   })
    //   .catch((err) => {
    //     const { errorMessages } = err.response.data;
    //     errorMessages?.forEach((errorMessage: string) => {
    //       displayErrorSnackbar(errorMessage);
    //     });
    //   });
  };

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    accept: acceptedFiles,
    maxFiles: FILES_COUNT,
    maxSize: FILE_SIZE,
    onDrop,
    onDropRejected,
    multiple: true,
  });

  return (
    <>
      <DropzoneContent
        getRootProps={getRootProps}
        getInputProps={getInputProps}
        isDragActive={isDragActive}
      />
      {uploadedFiles.length > 0 && (
        <DropzoneItem
          files={uploadedFiles}
          onRemove={removeUploadedFile}
          isUpload
        />
      )}
    </>
  );
};

export default Dropzone;
