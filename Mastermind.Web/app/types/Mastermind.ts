export type ReponseCreationPartie = {
  id: string;
}

export type ReponseTentative = {
  bienPlace: number
  malPlace: number
  tentativesRestantes: number
  etat: string
}

export type TentativeHistorique = {
  proposition: number[]
  bienPlaces: number
  malPlaces: number
}

export type ReponsePartie = {
    id: string
    tentativesRestantes: number
    etat: string
    tentatives: TentativeHistorique[]
}