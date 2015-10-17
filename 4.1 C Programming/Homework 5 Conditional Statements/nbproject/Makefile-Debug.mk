#
# Generated Makefile - do not edit!
#
# Edit the Makefile in the project folder instead (../Makefile). Each target
# has a -pre and a -post target defined where you can add customized code.
#
# This makefile implements configuration specific macros and targets.


# Environment
MKDIR=mkdir
CP=cp
GREP=grep
NM=nm
CCADMIN=CCadmin
RANLIB=ranlib
CC=gcc
CCC=g++
CXX=g++
FC=gfortran
AS=as

# Macros
CND_PLATFORM=MinGW-Windows
CND_DLIB_EXT=dll
CND_CONF=Debug
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/BeerTime.o \
	${OBJECTDIR}/BonusScore.o \
	${OBJECTDIR}/CheckForAPlayCard.o \
	${OBJECTDIR}/DigitAsWord.o \
	${OBJECTDIR}/ExchangeIfGreater.o \
	${OBJECTDIR}/MultiplicationSign.o \
	${OBJECTDIR}/NumberAsWords.o \
	${OBJECTDIR}/PlayWithIntDoubleAndString.o \
	${OBJECTDIR}/SortThreeNumbersWithNestedIfs.o \
	${OBJECTDIR}/TheBiggestOfFiveNumbers.o \
	${OBJECTDIR}/TheBiggestOfThreeNumbers.o \
	${OBJECTDIR}/ZeroSubset.o


# C Compiler Flags
CFLAGS=

# CC Compiler Flags
CCFLAGS=
CXXFLAGS=

# Fortran Compiler Flags
FFLAGS=

# Assembler Flags
ASFLAGS=

# Link Libraries and Options
LDLIBSOPTIONS=

# Build Targets
.build-conf: ${BUILD_SUBPROJECTS}
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_5_conditional_statements.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_5_conditional_statements.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_5_conditional_statements ${OBJECTFILES} ${LDLIBSOPTIONS}

${OBJECTDIR}/BeerTime.o: BeerTime.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/BeerTime.o BeerTime.c

${OBJECTDIR}/BonusScore.o: BonusScore.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/BonusScore.o BonusScore.c

${OBJECTDIR}/CheckForAPlayCard.o: CheckForAPlayCard.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/CheckForAPlayCard.o CheckForAPlayCard.c

${OBJECTDIR}/DigitAsWord.o: DigitAsWord.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/DigitAsWord.o DigitAsWord.c

${OBJECTDIR}/ExchangeIfGreater.o: ExchangeIfGreater.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/ExchangeIfGreater.o ExchangeIfGreater.c

${OBJECTDIR}/MultiplicationSign.o: MultiplicationSign.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/MultiplicationSign.o MultiplicationSign.c

${OBJECTDIR}/NumberAsWords.o: NumberAsWords.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/NumberAsWords.o NumberAsWords.c

${OBJECTDIR}/PlayWithIntDoubleAndString.o: PlayWithIntDoubleAndString.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PlayWithIntDoubleAndString.o PlayWithIntDoubleAndString.c

${OBJECTDIR}/SortThreeNumbersWithNestedIfs.o: SortThreeNumbersWithNestedIfs.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/SortThreeNumbersWithNestedIfs.o SortThreeNumbersWithNestedIfs.c

${OBJECTDIR}/TheBiggestOfFiveNumbers.o: TheBiggestOfFiveNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/TheBiggestOfFiveNumbers.o TheBiggestOfFiveNumbers.c

${OBJECTDIR}/TheBiggestOfThreeNumbers.o: TheBiggestOfThreeNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/TheBiggestOfThreeNumbers.o TheBiggestOfThreeNumbers.c

${OBJECTDIR}/ZeroSubset.o: ZeroSubset.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/ZeroSubset.o ZeroSubset.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_5_conditional_statements.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
