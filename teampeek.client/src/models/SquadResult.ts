import type { PlayerInfo } from './PlayerInfo';

export interface SquadResult {
  success: boolean;
  error?: string;
  players?: PlayerInfo[];
}
