import styled from '@emotion/styled';
import { Box, Alert, Typography } from '@mui/material';

export const CenteredTitle = styled(Typography)`
  text-align: center;
`;

export const SearchBarWrapper = styled(Box)`
  margin-bottom: 32px;
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
  width: 100%;
`;

export const CenteredBox = styled(Box)`
  display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: center;
`;

export const CenteredAlert = styled(Alert)`
  margin-top: 16px;
  margin-left: auto;
  margin-right: auto;
  display: block;
  width: fit-content;
  & .MuiAlert-icon {
    display: none;
  }
`;